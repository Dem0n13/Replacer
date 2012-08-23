using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Dem0n13.Replacer.Library.Tasks
{
    public class ReplacerTaskManager
    {
        public List<ReplacerTask> Tasks = new List<ReplacerTask>();
        public event EventHandler<ManagerProgressChangedEventArgs> ProgressChanged;

        public void OnProgressChanged(ManagerProgressChangedEventArgs e)
        {
            
            var handler = ProgressChanged;
            if (handler != null) handler(this, e);
        }

        public ReplacerTaskManager()
        {
            
        }

        public void RunAll()
        {
            for (var i = 0; i < Tasks.Count; i++)
            {
                var index = i;
                Tasks[i].ProgressChanged +=
                    (sender, args) => OnProgressChanged(new ManagerProgressChangedEventArgs(index, args));
            }
            /*var tf = new TaskFactory();
            var sch = tf.Scheduler;
            foreach (var replacerTask in Tasks)
            {
                tf.StartNew()
            }*/
            var task = Task.Factory.StartNew(Tasks[0].Run);
        }

        public void Stop()
        {
            
        }

        public void Cancel()
        {
            
        }
    }
}