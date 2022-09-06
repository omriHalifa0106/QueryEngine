using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Engine
{
    // this is service class with static functions
    static class Helper
    {
        /*
         * The function gets User and the fields that need to be displayed, and prints them accordingly.
         */
        public static void printFieldInUsersList(User user, string selectPart)
        {
            string[] fields = selectPart.Split(',');
            for (int i = 0; i < fields.Length; i++) 
            {
                fields[i] = fields[i].Trim();
                switch (fields[i])
                {
                    case "FullName":
                        Console.WriteLine("FullName:"+user.FullName);
                        break;
                    case "Email":
                        Console.WriteLine("Email:" + user.Email);
                        break;
                    case "Age":
                        Console.WriteLine("Age:" + user.Age);
                        break;
                }
            }
        }
        /*
         * The function gets Order and the fields that need to be displayed, and prints them accordingly.
         */
        public static void printFieldInOrdersList(Order order, string selectPart)
        {
            string[] fields = selectPart.Split(',');
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = fields[i].Trim();
                switch (fields[i])
                {
                    case "NumberOrder":
                        Console.WriteLine("NumberOrder:" + order.NumberOrder);
                        break;
                    case "Price":
                        Console.WriteLine("Price:" + order.Price);
                        break;
                }
            }
        }

        /*
         * Depending on the int, 
         * the function the field,the content and the operator, 
         * checks what the operator is and checks the condition between the field and the content and return the result.
         */
        public static bool Statement_int(int field, int content, string op)
        {
            switch (op)
            {
                case "==":
                    if (field == content)
                    {
                        return true;
                    }
                    break;
                case ">=":
                    if (field >= content)
                    {
                        return true;
                    }
                    break;
                case "<=":
                    if (field <= content)
                    {
                        return true;
                    }
                    break;
                case ">":
                    if (field > content)
                    {
                        return true;
                    }
                    break;
                case "<":
                    if (field < content)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }
        /*
         * Depending on the double, 
         * the function the field,the content and the operator, 
         * checks what the operator is and checks the condition between the field and the content and return the result.
         */
        public static bool Statement_double(double field, double content, string op)
        {
            switch (op)
            {
                case "==":
                    if (field == content)
                    {
                        return true;
                    }
                    break;
                case ">=":
                    if (field >= content)
                    {
                        return true;
                    }
                    break;
                case "<=":
                    if (field <= content)
                    {
                        return true;
                    }
                    break;
                case ">":
                    if (field > content)
                    {
                        return true;
                    }
                    break;
                case "<":
                    if (field < content)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        /*
         * Depending on the string, 
         * the function the field,the content and the operator, 
         * checks what the operator is and checks the condition between the field and the content and return the result.
         */
        public static bool Statement_String(String field, String content, string op)
        {
            if (field.Equals(content))
                return true;
            return false;
        }

        /*
         * The function accepts the condition and checks which operator in the condition returns it.
         */
        public static String containsOperator(string statement)
        {
            string operation = " ";

            if (statement.Contains("<="))
            {
                operation = "<=";
            }
            else if (statement.Contains(">="))
            {
                operation = ">=";
            }
            else if (statement.Contains(">"))
            {
                operation = ">";
            }
            else if (statement.Contains("<"))
            {
                operation = "<";
            }
            
            else if (statement.Contains("="))
            {
                operation = "==";
            }

            return operation;
        }
    }
}
