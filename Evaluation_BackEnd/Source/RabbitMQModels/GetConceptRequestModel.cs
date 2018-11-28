namespace Evaluation_BackEnd.RabbitMQModels 
{
    public class GetConceptRequestModel 
    {
        public string username {get;set;}
        public string tech{get;set;}
        public GetConceptRequestModel(string _username,string _tech)
        {
            username = _username;
            tech = _tech;
        }
    }
}