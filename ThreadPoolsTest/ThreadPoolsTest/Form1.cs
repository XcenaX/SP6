using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadPoolsTest
{
    public partial class Form1 : Form
    {
        Semaphore semaphore;
        List<ThreadInfo> threads= new List<ThreadInfo>();
        int numThread = 1;
        public Form1()
        {
            InitializeComponent();
            semaphore = new Semaphore(0,5, "TestSemaphore");

            ThreadPool.SetMaxThreads(0,5);
            ThreadPool.SetMinThreads(0,1);

            workThreads.View = View.Details;
            workThreads.GridLines = true;
            workThreads.FullRowSelect = true;

            waitThreads.View = View.Details;
            waitThreads.GridLines = true;
            waitThreads.FullRowSelect = true;

            createdThreads.View = View.Details;
            createdThreads.GridLines = true;
            createdThreads.FullRowSelect = true;

            AddWorkItem = new Action<int>(delegate (object item) {
                workThreads.Items.Add(item as string);
            });
            ReplaceWorkItem = new Replace<int>(delegate ( int index) {
                foreach (ListViewItem item in workThreads.Items)
                {
                    var splited = item.ToString().Split(' ');
                    if (splited[2] == index.ToString() )
                    {
                        workThreads.Items.Remove(item);
                    }
                }
                
            });

            AddWaitItem = new Action<int>(delegate (object item) {
                waitThreads.Items.Add(item as string);
            });
            ReplaceWaitItem = new Replace<int>(delegate (int index) {
                waitThreads.Items.RemoveAt(index);
            });

            ChangeWorkText = new Change<string>(delegate (string text, int index) {
                waitThreads.Items[index].Text = text;
            });

            ReplaceCreatedItem = new ReplaceItem(delegate (object item) {
                createdThreads.Items.Remove(createdThreads.SelectedItems[0]);
            });
        }

        private delegate void Action<T>(object item);
        private delegate void Replace<T>(int index);
        private delegate void Change<T>(string text, int index);
        private delegate void GetSelectedSplitItem(string[] text);
        private delegate void GetSelectedItem(ListViewItem text);
        private delegate void ReplaceItem(object item);

        private Action<int> AddWorkItem;
        private Replace<int> ReplaceWorkItem;
        private ReplaceItem ReplaceCreatedItem;
        private Action<int> AddWaitItem;
        private Replace<int> ReplaceWaitItem;
        private Change<string> ChangeWorkText;

        

        private void createButton_Click(object sender, EventArgs e)
        {
            //ThreadPool.QueueUserWorkItem(Counter, semaphore);
            createdThreads.Items.Add("Поток "+ numThread + " -> Создан");
            numThread++;
        }

        private void Counter(object state)
        {                        
            
            int count = 0;

            var item = "";
            waitThreads.Invoke(new GetSelectedItem((x) => { item = waitThreads.Items[0].Text; }), new ListViewItem());
            var splited = item.Split(' ');

            workThreads.Invoke(new Action<string>((x) => workThreads.Items.Add(x as string)), "Поток " + splited[1] + " -> " + count);
            waitThreads.Invoke(new Replace<int>((x) => waitThreads.Items.RemoveAt(x)), 0);
                bool isStop = true;

            while (isStop)
            {
                int element = (int)state;
                isStop = threads.Where(thread => thread.ProgrammThreadId == element).ToList()[0].IsActive;
                if (!isStop)
                {
                    var result = workThreads.SelectedItems[0].SubItems[0].Text.Split(' ');
                    workThreads.Invoke(ReplaceWorkItem, Convert.ToInt32(result[1]));
                    return;
                }

                count++;
                
                var newText = "Поток " + splited[1] + " -> " + count;
                var id = Thread.CurrentThread.ManagedThreadId - 3;
                
                workThreads.Invoke(new Change<string>((text,index) => workThreads.Items[index].Text = text),new object[] {newText,id });

                Thread.Sleep(1000);
            }
        }

        private void AddToQueue(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            createdThreads.Invoke(new GetSelectedItem((x) => { item = createdThreads.SelectedItems[0]; }), item);
            createdThreads.Invoke(ReplaceCreatedItem, new object());

            var splited = item.Text.Split(' ');
            item.Text = splited[0] + " " + splited[1] + " -> Ожидает";
            waitThreads.Invoke(AddWaitItem, item.Text);
            threads.Add(new ThreadInfo(Thread.CurrentThread.ManagedThreadId, Convert.ToInt32(splited[1]), true));
            ThreadPool.QueueUserWorkItem(Counter, threads[threads.Count-1].ProgrammThreadId);               
        }

        private void RemoveThread(object sender, EventArgs e)
        {            
            string[] text = new string[1];
            workThreads.Invoke(new GetSelectedSplitItem((x) => { text = workThreads.SelectedItems[0].SubItems[0].Text.Split(' '); }), text);

            var result = threads.Where(thread => thread.ProgrammThreadId == Convert.ToInt32(text[1])).ToList()[0];
            
            foreach(var thread in threads)
            {
                if(thread.Id == result.Id && thread.ProgrammThreadId == result.ProgrammThreadId)
                {                    
                    result.IsActive = false;
                }
            }            
        }

        private void ChangeThreads(int workThread, int maxCount)
        {
            var currentThreads = Process.GetCurrentProcess().Threads;
            for(int i = maxCount; i< workThread; i++)
            {
                currentThreads[maxCount].Dispose();
                
            }
        }

        private void ChangeSemaphoreSize(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0) return;
            int workThread, maxCount;
            ThreadPool.GetMaxThreads(out workThread,out maxCount);

            ThreadPool.SetMaxThreads(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value));
            semaphore = new Semaphore(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value));
            if (numericUpDown1.Value < maxCount)
            {
                ChangeThreads(workThread, Convert.ToInt32(numericUpDown1.Value));
            }
        }
    }
}
