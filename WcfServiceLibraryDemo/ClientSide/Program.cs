using ClientSide.EvalServiceReference;
using EvalServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EvalServiceClient channel = new EvalServiceClient("BasicHttpBinding_IEvalService");
            
            try
            {
                

                Eval eval = new Eval(0,"test",DateTime.Now, "test");

                Eval eval1 = new Eval(1,"test1",DateTime.Now,"test1");
                

                Eval eval2 = new Eval(2,"test2",DateTime.Now,"test2");

                channel.SubmitEval(eval);
                channel.SubmitEval(eval1);
                channel.SubmitEval(eval2);

                channel.DeleteEval(eval1.Id);
                channel.DeleteEval(eval2.Id);

                channel.SubmitEval(eval2);

                
                List<Eval> evals = channel.GetEvals();

                EvalDetails(evals);
                
                
                Console.ReadLine();

                channel.Close();

            }
            catch (FaultException fe)
            {

                Console.WriteLine(fe.Message);
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
        public static void EvalDetails(List<Eval> evals)
        {
            
            Console.WriteLine("Number of Evals = {0}", evals.Count);

            foreach (var item in evals)
            {

                 Console.WriteLine($"Evals Details :" +
                    $" {item.Id},{item.Name},{item.Comment},{item.TimeSent} ");
            }
        }
    }
}
