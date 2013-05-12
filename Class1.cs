using System;

public class Class1
{

    static void Main()
    {

        // We will use Stream's BeginRead and EndRead for this sample.
        Stream inputStream = Console.OpenStandardInput();

        // To convert an asynchronous operation that uses the IAsyncResult pattern to a function that returns an IObservable, use the following format.  
        // For the generic arguments, specify the types of the arguments of the Begin* method, up to the AsyncCallback.
        // If the End* method returns a value, append this as your final generic argument.
        var read = Observable.FromAsyncPattern<byte[], int, int, int>(inputStream.BeginRead, inputStream.EndRead);

        // Now, you can get an IObservable instead of an IAsyncResult when calling it.
        byte[] someBytes = new byte[10];
        IObservable<int> observable = read(someBytes, 0, 10);



    }
}
