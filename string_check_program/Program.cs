using System;
using System.Collections.Generic;

namespace string_check_program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("問題数を入力");
            var n = int.Parse(Console.ReadLine());
            //正答と回答のペアを格納するためのディクショナリ定義
            var sdic = new SortedDictionary<string,string>();
            for(var i = 1; i <= n; i++)
            {
                Console.WriteLine($"{i}題目の単語を入力してください");
                var q = Console.ReadLine();
                Console.WriteLine($"{i}題目の回答を入力してください");
                var a = Console.ReadLine();
                sdic.Add(q, a);
            }

            //単語完全一致：２点
            //長さ同じで１文字異なる：1点
            //その他、長さ異なる：０点

            var p = new Program();
            
            var score = 0;
            foreach(var key in sdic.Keys)
            {
                //長さチェックの結果を定義
                var l_check = p.LengthCheck(key, sdic[key]);
                
                if (l_check== 1)
                {
                    //スペルチェック
                    var s_check = p.SpellCheck(key, sdic[key]);
                    if (s_check == 0)
                    {
                        score += 2;
                    }else if (s_check == 1)
                    {
                        score += 1;
                    }
                    else
                    {
                        score += 0;//2文字以上スペル違う場合は0点
                    }
                }
                else
                {
                    score += 0;//長さが異なる場合は容赦無く0点
                }
            }

            foreach(var s in sdic)
            {
                Console.WriteLine($"正答:{ s.Key}回答:{s.Value}");
            }
            Console.WriteLine($"{score}点です");
           
        }
        //同じクラス内にメソッド定義。長さをチェックし、結果を数字で返す
        public int LengthCheck(string q, string a)
        {
            //長さが一致する場合は1を、不一致の場合は0を返す
            var result = 0;
            if (q.Length == a.Length)
            {
                result = 1;
            }
            return result;
        }
        //同じクラス内にメソッド定義。スペルをチェックし、結果を数字で返す
        public int SpellCheck(string q, string a)
        {

            var result = 0;
            for (var i = 0;i < q.Length; i++){
                if (q[i] != a[i])
                {
                    result += 1;//異なるスペル検知するごとに1加算
                }
            }
            return result;
        }
    }
    
}
