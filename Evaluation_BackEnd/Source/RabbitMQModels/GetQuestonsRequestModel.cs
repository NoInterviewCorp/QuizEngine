namespace Evaluation_BackEnd.RabbitMQModels {
        public class GetQuestionsRequestModel {
            public string username { get; set; }
            public string tech { get; set; }
            public string concept;
            public GetQuestionsRequestModel (string _username, string _tech, string _concept) {
                username = _username;
                tech = _tech;
                concept = _concept;
            }
        }
}