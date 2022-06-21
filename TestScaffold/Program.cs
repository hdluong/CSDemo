using System;

namespace TestScaffold
{
    class Program
    {
        static void Main(string[] args)
        {
            // dotnet ef dbcontext scaffold -o Models -f -d "Data Source = SM116\MSSQL_SERVER;Initial Catalog = xtlab;User ID = sa;Password = 123" "Microsoft.EntityFrameworkCore.SqlServer"
            // "Data Source = SM116\MSSQL_SERVER;Initial Catalog = xtlab;User ID = sa;Password = 123"
        }
    }
}
