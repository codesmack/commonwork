class TaskThrottle
    {
        List<Task> lstTask = new List<Task>();

        public void AddWork(Func<int, int> taskToRun, int j)
        {
            if (lstTask.Count > 0 && lstTask.Select(x => x.Status != TaskStatus.RanToCompletion).Count() % 3 == 0)
            {
                Console.WriteLine("wait for 4-3 task");
                Task.WaitAll(lstTask.ToArray());
            }

            lstTask.Add(Task.Run(() => taskToRun(j)));
        }

        public void AllWorkOver()
        {
            Console.WriteLine("wait for remaining");
            Task.WaitAll(lstTask.ToArray());
            Console.WriteLine("all over");
            lstTask.Clear();
        }
    }


static void RunPara()
        {
            List<Task> lstTask = new List<Task>();
            Sample samp = new Sample();

            for (int i = 0; i < 30; i++)
            {
                if (i != 0 && lstTask.Select(x => x.Status != TaskStatus.RanToCompletion).Count() % 3 == 0)
                {
                    Console.WriteLine("wait for 4-3 task");
                    Task.WaitAll(lstTask.ToArray());
                }

                int j = i;
                lstTask.Add(Task.Run(() => samp.Startup(j)));
            }

            Console.WriteLine("wait for remaining");
            Task.WaitAll(lstTask.ToArray());
            Console.WriteLine("all over");
        }
