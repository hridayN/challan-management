namespace ChallanManagement.API
{
    public interface IChallanService
    {
        string CreateChallan(ChallanRequest challanRequest);
        ChallanResponse GetChallans(ChallanRequest challanRequest);
        string SubmitChallan(ChallanRequest challanRequest);
    }
}
