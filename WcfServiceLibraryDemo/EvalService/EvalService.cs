using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary

{
    [DataContract]
    public class Eval
    {
        public Eval(int Id, string Name, DateTime TimeSent, string Comment )
        {
            this.Id = Id;   
            this.Name = Name;
            this.TimeSent = TimeSent;
            this.Comment = Comment;
        }
        [DataMember]
        public int Id;
        [DataMember]
        public string Name;
        [DataMember]
        public DateTime TimeSent;
        [DataMember]
        public string Comment;
    }
    [ServiceContract]
    public interface IEvalService
    {
        [OperationContract]
        void SubmitEval(Eval eval);
        [OperationContract]
        void UpdateEval(int id, Eval eval);
        [OperationContract]
        void DeleteEval(int id);
        [OperationContract]
        List<Eval> GetEvals();
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService : IEvalService
    {
        List<Eval> evals = new List<Eval>();
        public List<Eval> GetEvals()
        {
            return evals;
        }
        public void DeleteEval(int id)
        {

           var evalToDelete = evals.FirstOrDefault(e => e.Id == id);
            evals.Remove(evalToDelete); 
        }
        public void UpdateEval(int id, Eval eval)
        {

            var evalToUpdate = evals.FirstOrDefault(e => e.Id == id);
            evalToUpdate.Comment = eval.Comment;    
            evalToUpdate.Name = eval.Name;
            evals.Insert(id, evalToUpdate);

        }

        public void SubmitEval(Eval eval)
        {
            evals.Add(eval);
        }
    }
}