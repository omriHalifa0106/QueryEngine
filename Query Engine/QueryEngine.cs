using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Query_Engine
{
    class QueryEngine
    {
        /*
         * The function receives the condition string in the query and the object it needs to check, 
         * the function divides the complex condition into separate conditions, 
         * runs on them in a loop and sends to the condition function which checks the condition and returns an answer. 
         * It then replaces the condition with a string in the Boolean answer 
         * and then runs in a loop which replaces the results of the complex condition into one answer and returns it.
         */
        static bool whereExpression(string whereStr, Object datafield)
        {
            string[] separatingStrings = {"AND", "and", "OR", "or" }; 
            string[] expression = whereStr.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries); // Split the complex conditions to simple conditons

            bool flag;//For the result of the simple condition

            for (int i = 0; i < expression.Length; i++) // Runs on the simple conditions
            {
                //Remove the parenthesis if any
                expression[i] = expression[i].Replace('(', ' ').Trim();
               expression[i] = expression[i].Replace(')', ' ').Trim();

               flag = condition(datafield, expression[i]); // result of the simple condition
                //replace the simple condition to the boolean answer in the complex condition
                if (flag == true)
                    whereStr = whereStr.Replace(expression[i], "True"); 
                else
                    whereStr = whereStr.Replace(expression[i], "False");
            }
            whereStr = whereStr.ToLower();

            /*
             * This loop accepts the complex condition as follows for example: true and (true or false) 
             * and returns the boolean answer of the condition
             */
            string previous = string.Empty;
            while (whereStr != previous) 
            {
                previous = whereStr;
                whereStr = whereStr.Replace("true and false", "false");
                whereStr = whereStr.Replace("true and true", "true");
                whereStr = whereStr.Replace("false and true", "false");
                whereStr = whereStr.Replace("false and false", "false");
                whereStr = whereStr.Replace("false or false", "false");
                whereStr = whereStr.Replace("true or false", "true");
                whereStr = whereStr.Replace("true or true", "true");
                whereStr = whereStr.Replace("false or true", "true");
                whereStr = whereStr.Replace("(false)", "false");
                whereStr = whereStr.Replace("(true)", "true");
                whereStr = whereStr.Replace("not false", "true");
                whereStr = whereStr.Replace("not true", "false");
            }

            if (whereStr.Equals("true")) 
                return true;
            return false;
        }


        /*
         * The function accepts the object and the simple condition 
         * and returns the answer to the condition.
         */
        static bool condition(Object obj,string statement)
        {
            bool flag = false;
            string[] separatingStrings = { ">", "<", "<=", ">=","=" };
            string[] expression = statement.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);// Split the simple conditions to field and content
            string operation = Helper.containsOperator(statement).Trim(); //check what the operator that exist in the simple condion
            string field = expression[0].Trim().Replace("(","");// take the field
            string content = expression[1].Trim().Replace(")", ""); // take the contant

            if (obj is User) // if the object is user
            {
                User user = (User)obj;// downcasting to user
                //check the field and check if the condition is true or false
                switch (field)
                {
                    case "FullName":
                       flag = Helper.Statement_String(user.FullName,content.Replace("'",""), operation);
                        break;
                    case "Email":
                        flag = Helper.Statement_String(user.Email, content.Replace("'", ""), operation);
                        break;
                    case "Age":
                        flag = Helper.Statement_int(user.Age, int.Parse(content), operation);
                        break;
                }
            }

            if (obj is Order)// if the object is order
            {
                Order order = (Order)obj;// downcasting to user
                //check the field and check if the condition is true or false
                switch (field)
                {
                    case "NumberOrder":
                        flag = Helper.Statement_int(order.NumberOrder, int.Parse(content), operation);
                        break;
                    case "Price":
                        flag = Helper.Statement_double(order.Price, double.Parse(content), operation);
                        break;
                }
            }
            return flag;
        }

       

        static void Main(string[] args)
        {
            //create and print the data base (the lists):
            Data data = new Data();
            data.CreateDataBase();
            data.printDataBase();
            Console.WriteLine("******");
           
            Console.WriteLine("Welcome to my Query Engine!!");
            Console.WriteLine("Please enter a sql query:");
            string sqlMessege = Console.ReadLine();

            //Input test, check if the query is in the format : from <Source> where <Expression> select <Field>
            if ((!sqlMessege.Contains("from") || !sqlMessege.Contains("where") || !sqlMessege.Contains("select") || !(sqlMessege.IndexOf("from") < sqlMessege.IndexOf("where") && sqlMessege.IndexOf("where")< sqlMessege.IndexOf("select"))))
            {
                Console.WriteLine("Invaild query!");
                Console.ReadLine();
                Environment.Exit(0);
            }



            int start, end;

            //anaylze the query and split it to this pattern: from <Source> where <Expression> select <Field>;

            //split to source, from part:
            start = sqlMessege.IndexOf("from") + "from".Length;
            end = sqlMessege.IndexOf("where");
            string fromPart = sqlMessege.Substring(start, end - start).Trim();

            //split to expression, where part:
            start = sqlMessege.IndexOf("where") + "where".Length;
            end = sqlMessege.LastIndexOf("select");
            string wherePart = sqlMessege.Substring(start, end - start).Trim();

            //split to fields, select part:
            string selectPart = sqlMessege.Substring(sqlMessege.LastIndexOf("select") + "select".Length).Trim();

            Console.WriteLine("My Query Engine results...\n");

            //if the souece is Users,run on the list of users, and check if the expression is true, and if so, print the relevant fields:
            if (fromPart.Equals("Users"))
            {
                foreach(var user in data.users)
                {
                    if(whereExpression(wherePart,user))
                    {
                        Helper.printFieldInUsersList(user, selectPart);
                        Console.WriteLine("----");
                    }
                    
                }
            }
            else if(fromPart.Equals("Orders")) //if the souece is Users,run on the list of orders, and check if the expression is true, and if so, print the relevant fields:
            {
                foreach (var order in data.orders)
                {
                    if (whereExpression(wherePart, order))
                    {
                        Helper.printFieldInOrdersList(order, selectPart); 
                        Console.WriteLine("----");
                    }
                   
                }
            }
            Console.ReadLine();
        }

    }
}


/*
 * SQL Query test:
  1) from Users where FullName = 'John Doe' or Age > 30 select FullName,Email,Age
  2) from Users where Email = 'selected.databases@ravendb.net' select FullName, Email
  3) from Users where Email = 'jobs@ravendb.net' or Email = 'jobs@hibernatingrhinos.com' select FullName, Email
  4) from Users where Email = 'jobs@ravendb.net' or Age > 18 and Age < 99 select FullName, Email
  5) from Users where (FullName = 'foo' or FullName = 'bar') and Age < 99 select FullName, Email
  6) from Orders where Price < 99 or NumberOrder > 100 select Price, NumberOrder
 */
