using EvalServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EvalServiceClient channel = new EvalServiceClient();
            try
            {
                Eval eval = new Eval();
                eval.Name = "Test";
                eval.TimeSent = DateTime.Now;
                eval.Comment = "Test22";

                channel.SubmitEvalAsync(eval);
                channel.SubmitEvalAsync(eval);



                channel.GetEvalsAsync();

                Console.WriteLine("EVAL = {0}", eval.ToString());

                //close
                channel.Close();

            }
            catch (FaultException fe)
            {
                Console.WriteLine(fe.Message);
                //abort
                channel.Abort();
            }

            catch (CommunicationException ce)
            {
                Console.WriteLine(ce.Message);
                channel.Abort();
            }
            catch (TimeoutException te)
            {
                Console.WriteLine(te.Message);
                channel.Abort();
            }
        }
    }
}
