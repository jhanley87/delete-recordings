// Install the C# / .NET helper library from twilio.com/docs/csharp/install

using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;


class Program
{
    static async Task Main(string[] args)
    {
        // Find your Account SID and Auth Token at twilio.com/console
        // and set the environment variables. See http://twil.io/secure
        string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

        TwilioClient.Init(accountSid, authToken);

        //The flters for fetching of the call resources
        string fromNumber = "";

        //set this to false for a dry run
        bool shouldActuallyDelete = false;

        //Here we fetch all calls for a given filter criteria, in this case from number and status 'completed'
        var calls = await CallResource.ReadAsync(
            status: CallResource.StatusEnum.Completed,
            from: new Twilio.Types.PhoneNumber(fromNumber)
        );

        //loop through calls
        foreach (var call in calls)
        {
            Console.WriteLine($"call sid is {call.Sid}");

            //fetch recordings for a given call and loop them
            var recordings = await RecordingResource.ReadAsync(callSid: call.Sid);

            foreach(var recording in recordings)
            {
                // if we should delete the call then delete it, else just output
                if (shouldActuallyDelete)
                {
                    Console.WriteLine($"Deleting {recording.Sid}");
                    RecordingResource.Delete(pathSid: recording.Sid);
                }
                else
                {
                    Console.WriteLine($"Would have deleted {recording.Sid}");
                }
            }
        }

        Console.ReadKey();
    }
}
