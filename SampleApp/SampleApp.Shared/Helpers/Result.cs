namespace Shared.Helpers {
    // <summary>
    //  Presentation of Domain Result
    // </summary>
    public class Result<T> where T : class {
        public Result(T content, ResultState state) {
            Content = content;
            State = state;
        }

        // State of processing
        ResultState State {get; set;}

        // Processing entity
        T Content {get; set;}
    }
}
