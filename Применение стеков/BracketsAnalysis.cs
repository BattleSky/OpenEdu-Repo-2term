using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Применение_стеков
{ /*
 * Стеки для анализа скобочных выражений
 *
 * Идея:
 * В стек складываются открывающиеся скобки, и если программа находит закрывающуюся скобку,
 * то осуществляется проверка верхней позации в стеке, и если совпадает
 * то она снимается и ведется поиск следующей скобки
 */ 
    public class BracketsAnalysis
        { 
            public static void Main1()
            {
                Console.WriteLine(IsCorrectStringDRYok("(([])[])"));
                Console.WriteLine(IsCorrectStringDRYok("((][])"));
                Console.WriteLine(IsCorrectStringDRYok("((("));
                Console.WriteLine(IsCorrectStringDRYok("(x)"));
            }

            public static bool IsCorrectStringDRYnotok(string str)
            {
                var stack = new Stack<char>();
                // стеки и очереди уже существуют в платформе .net,
                // их не надо создавать ручками

                foreach (var e in str)
                { // решение соответствующее правилу DRY - ниже
                    switch (e)
                    {
                        case '[':
                        case '(':
                            stack.Push(e);
                            break;

                        case ']':
                            if (stack.Count == 0) return false;
                            if (stack.Pop() != '[') return false;
                            break;

                        case ')':
                            if (stack.Count == 0) return false;
                            if (stack.Pop() != '(') return false;
                            break;
                        default:
                            return false;
                    }
                }
                return stack.Count == 0;
            }

            //Немного улучшим решение, обойдемся без DRY
            public static bool IsCorrectStringDRYok(string str)
            {
                // для недопущения использования DRY, создаем словарь
                var pairs = new Dictionary<char, char>();
                pairs.Add('(', ')');
                pairs.Add('[', ']');
                pairs.Add('<', '>');
                pairs.Add('{', '}');
                // ключ - значение (так, на всякий)
                var stack = new Stack<char>();
                foreach (var e in str)
                {
                    if (pairs.ContainsKey(e)) stack.Push(e);
                    // символ является открывающейся скобкой, если соответствует одному из ключей словаря
                    else if (pairs.ContainsValue(e))
                    //  символ является закрывающейся скобкой, если соответствует одному из значений словаря
                    {
                        if (stack.Count == 0 || pairs[stack.Pop()] != e) return false;
                    }
                    else return false;
                }
                return stack.Count == 0;
            }

        }
    }

