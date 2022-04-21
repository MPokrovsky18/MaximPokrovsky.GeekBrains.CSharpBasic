namespace BelieveOrNotBelieve
{
    public class Question
    {
        #region Public Propirties

        public string Text { get; set; }
        public bool TrueFalse { get; set; }

        #endregion

        #region Constructors

        public Question(string text, bool trueFalse)
        {
            Text = text;
            TrueFalse = trueFalse;
        }

        public Question()
        {

        }

        #endregion
    }
}
