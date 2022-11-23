namespace ManagementService.Services.Data.RequestManager
{
    using System.Reflection;

    public static class RequestParamsManager
    {
        public static (string RequestText, object[] Values) GetParamsForInsertRequest(object tableClass)
        {
            // Get type
            Type tableClassType = tableClass.GetType();

            // Get all properties where each represents a column in the current table object
            var columns = tableClassType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Get table name
            string tableName = tableClassType.Name;
            tableName = char.ToLower(tableName[0]) + tableName[1..];

            // Prepare columns values
            var columnsValues = columns.Select(x => x.GetValue(tableClass, null)).ToArray();

            // Prepare request text
            var columnNames = string.Join(", ", columns.Select(x => x.Name));
            var valuesPlaceholder = string.Join(", ", new string('?', columnsValues.Length));

            var requestText = $"INSERT INTO {tableName} ({columnNames}) VALUES ({valuesPlaceholder})";

            // Return request params
            return (requestText, columnsValues);
        }
    }
}
