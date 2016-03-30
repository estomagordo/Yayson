using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yayson
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Yayson
    {
        public JsonToken MakeToken(string s)
        {
            var sb = new StringBuilder();
            var stack = new Stack<IJsonCollection>();
            IJsonCollection collection;
            collection = new JsonList();
            var root = collection as JsonList;
            var inString = false;

            foreach (var c in s)
            {
                if (char.IsWhiteSpace(c) && !inString)
                {
                    continue;
                }
                if (collection is JsonObject)
                {
                    var collObj = collection as JsonObject;
                    var valueString = string.Empty;

                    if (!collObj.KeyDone)
                    {        
                        if (inString)
                        {
                            if (c == '"')
                            {
                                inString = false;
                            }                            
                            else
                            {
                                sb.Append(c);
                            }
                        }     
                        else
                        {
                            if (c == '"')
                            {
                                inString = true;
                            }
                            else
                            {
                                collObj.Key = sb.ToString();
                                sb.Clear();
                                collObj.InKey = false;
                                collObj.KeyDone = true;
                            }                            
                        }                   
                    }
                    else
                    {                        
                        collObj.InValue = true;
                        
                        if (inString)
                        {
                            if (c == '"')
                            {
                                valueString = sb.ToString();
                                sb.Clear();
                                inString = false;
                                collObj.InValue = false;
                                collObj.KeyDone = false;
                            }
                            else
                            {
                                sb.Append(c);
                            }
                        }
                        else
                        {
                            if (c == ',')
                            {
                                valueString = sb.ToString();
                                sb.Clear();
                                collObj.InValue = false;
                                collObj.KeyDone = false;
                            }
                            else if (collection.IsStopper(c))
                            {
                                valueString = sb.ToString();
                                sb.Clear();

                                collObj.InValue = false;
                                collObj.KeyDone = false;
                                JsonObject thisObject = collection as JsonObject;
                                collection = stack.Pop();
                                collection.Add(collection.Key, thisObject);
                            }
                            else if (c == '[')
                            {
                                stack.Push(collection);
                                collection = new JsonList();
                            }
                            else if (c == '{')
                            {
                                stack.Push(collection);
                                collection = new JsonObject();
                            }
                            else
                            {
                                sb.Append(c);
                            }
                        }                        
                    }

                    if (!string.IsNullOrWhiteSpace(valueString))
                    {
                        var valueToken = JsonTokenFactory.MakeToken(valueString);
                        collObj.Add(collObj.Key, valueToken);
                        if (valueToken is IJsonCollection)
                        {
                            stack.Push(collection);
                            collection = (valueToken as IJsonCollection);
                        }                                
                    }
                }
                else
                {
                    var collList = collection as JsonList;
                    var valueString = string.Empty;
                    
                    if (inString)
                    {
                        if (c == '"')
                        {
                            valueString = sb.ToString();
                            sb.Clear();
                            inString = false;
                        }
                        else
                        {
                            sb.Append(c);
                        }
                    }
                    else
                    {
                        if (c == ',')
                        {
                            valueString = sb.ToString();
                            sb.Clear();
                        }
                        else if (collection.IsStopper(c))
                        {
                            valueString = sb.ToString();
                            sb.Clear();

                            JsonList thisList = collection as JsonList;
                            collection = stack.Pop();
                            collection.Add(collection.Key, thisList);
                        }
                        else if (c == '[')
                        {
                            stack.Push(collection);
                            collection = new JsonList();
                        }
                        else if (c == '{')
                        {
                            stack.Push(collection);
                            collection = new JsonObject();
                        }
                        else
                        {
                            sb.Append(c);
                        }
                    }                    

                    if (!string.IsNullOrWhiteSpace(valueString))
                    {
                        var valueToken = JsonTokenFactory.MakeToken(valueString);
                        collList.Add(string.Empty, valueToken);
                        if (valueToken is IJsonCollection)
                        {
                            stack.Push(collection);
                            collection = (valueToken as IJsonCollection);
                        }
                    }
                }
            }

            return root[0];
        }
    }
}
