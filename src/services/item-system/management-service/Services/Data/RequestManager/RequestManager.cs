namespace ManagementService.Services.Data.RequestManager
{
    using ManagementService.Data;

    public class RequestManager : IRequestManager
    {
        private readonly AppDbContext db;

        public RequestManager(AppDbContext db)
        {
            this.db = db;
        }

        public Task MakeInsertRequestAsync(object tableClass)
        {
            var (requestText, values) = RequestParamsManager.GetParamsForInsertRequest(tableClass);

            var prepare = this.db.Session.Prepare(requestText);

            var statement = prepare.Bind(values);

            return this.db.Session.ExecuteAsync(statement);
        }
    }
}
