using GameConsole.Model.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string aaa = "\"YaKUEjjcTErRbsI";
            var test = System.Text.Encoding.Default.GetBytes(aaa);



            Random r = new Random();

            Soldier s1 = new Soldier();

            //Console.Write("請輸入角色名：");
            //s1.Name = Console.ReadLine();
            s1.Name = "李青鋒";
            s1.Attack = r.Next(10, 101);
            s1.Blood = r.Next(2000, 3501);
            zhaoshi z1 = new zhaoshi();
            //Console.Write("請輸入技能1名稱：");
            //z1.Name = Console.ReadLine();
            z1.Name = "風刀";
            z1.Attack = r.Next(100, 201);
            s1.Skill = z1;
            zhaoshi z2 = new zhaoshi();
            //Console.Write("請輸入技能2名稱：");
            //z2.Name1 = Console.ReadLine();
            z2.Name1 = "風擊";
            z2.Attack1 = r.Next(150, 250);
            s1.Skill1 = z2;
            zhaoshi z3 = new zhaoshi();
            //Console.Write("請輸入必殺技名稱：");
            //z3.Name = Console.ReadLine();
            z3.Name = "風捲殘樓";
            z3.Attack = r.Next(350, 501);
            s1.Slay = z3;
            //閃避
            s1.Miss = r.Next(0, 20);
            //格擋
            s1.block = r.Next(0, 50);

            Soldier s2 = new Soldier();
            //Console.Write("請輸入角色名：");
            //s2.Name = Console.ReadLine();
            s2.Name = "普通人";
            s2.Attack = r.Next(10, 101);
            s2.Blood = r.Next(2000, 3501);
            zhaoshi z4 = new zhaoshi();
            //Console.Write("請輸入技能1名稱：");
            //z4.Name = Console.ReadLine();
            z4.Name = "普通的一拳";
            z4.Attack = r.Next(100, 201);
            s2.Skill = z4;
            zhaoshi z5 = new zhaoshi();
            //Console.Write("請輸入技能2名稱：");
            //z5.Name1 = Console.ReadLine();
            z5.Name1 = "普通的一腳";
            z5.Attack1 = r.Next(150, 250);
            s2.Skill1 = z5;
            zhaoshi z6 = new zhaoshi();
            //Console.Write("請輸入必殺技名稱：");
            //z6.Name = Console.ReadLine();
            z6.Name = "認真的一拳";
            z6.Attack = r.Next(350, 901);
            s2.Slay = z6;

            s2.Miss = r.Next(0, 20);
            s2.block = r.Next(0, 50);

            Console.WriteLine("============================================戰士資訊展示=============================================");
            Console.WriteLine("戰士1：" + s1.Name + "，攻擊：" + s1.Attack + "，閃避：" + s1.Miss + "，格擋:" + s1.block + ", 血量：" + s1.Blood + "，技能1：" + s1.Skill.Name + "，" + s1.Skill.Attack + "，技能2：" + s1.Skill1.Name1 + "，" + s1.Skill1.Attack1 + "，必殺技：" + s1.Slay.Name + "，" + s1.Slay.Attack);
            Console.WriteLine("戰士2：" + s2.Name + "，攻擊：" + s2.Attack + "，閃避：" + s2.Miss + "，格擋:" + s1.block + "，血量：" + s2.Blood + "，技能1：" + s2.Skill.Name + "，" + s2.Skill.Attack + "，技能2：" + s2.Skill1.Name1 + "，" + s2.Skill1.Attack1 + "，必殺技：" + s2.Slay.Name + "，" + s2.Slay.Attack);
            Console.WriteLine("按下任意鍵開始戰鬥！！！");
            Console.ReadKey();

            int count = 1;
            while (true)
            {
                Console.WriteLine("==========================第" + count + "回合==========================");
                System.Threading.Thread.Sleep(1500);

                if (r.Next(0, 101) < s2.Miss)
                {
                    Console.WriteLine(s2.Name + "躲避了此次攻擊！！！");
                }
                else
                {
                    if (r.Next(0, 101) < s2.block)
                    {
                        {
                            Console.WriteLine(s2.Name + "格擋了此次攻擊！！！");
                        }
                    }
                    else
                    {
                        int ss1 = r.Next(0, 100);

                        if (ss1 > 90)//開大招
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("【" + s1.Name + "】對【" + s2.Name + "】釋放了★★★★★▄︻┻═┳一" + s1.Slay.Name + "★★★★★，造成" + s1.Slay.Attack + "點傷害，【" + s2.Name + "】剩餘" + (s2.Blood - s1.Slay.Attack) + "點血量");
                            Console.WriteLine();
                            //S2扣血
                            s2.Blood -= s1.Slay.Attack;
                        }
                        else if (ss1 >= 70 && ss1 <= 90)//開小招
                        {
                            int ss3 = r.Next(0, 100);

                            if (ss3 >= 0 && ss3 < 50)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.WriteLine("【" + s1.Name + "】對【" + s2.Name + "】釋放了☆☆☆" + s1.Skill.Name + "☆☆☆，造成" + s1.Skill.Attack + "點傷害，【" + s2.Name + "】剩餘" + (s2.Blood - s1.Skill.Attack) + "點血量");
                                Console.WriteLine();
                                //S2扣血
                                s2.Blood -= s1.Skill.Attack;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;

                                Console.WriteLine("【" + s1.Name + "】對【" + s2.Name + "】釋放了☆☆☆" + s1.Skill1.Name1 + "☆☆☆，造成" + s1.Skill1.Attack1 + "點傷害，【" + s2.Name + "】剩餘" + (s2.Blood - s1.Skill1.Attack1) + "點血量");
                                Console.WriteLine();
                                //S2扣血
                                s2.Blood -= s1.Skill.Attack;
                            }
                        }
                        else//普通攻擊
                        {
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("【" + s1.Name + "】攻擊了【" + s2.Name + "】，造成" + s1.Attack + "點傷害，【" + s2.Name + "】剩餘" + (s2.Blood - s1.Attack) + "點血量");
                            Console.WriteLine();
                            //S2扣血
                            s2.Blood -= s1.Attack;
                        }

                        //判斷戰士2是否陣亡
                        if (s2.Blood <= 0)
                        {
                            Console.WriteLine("【" + s2.Name + "】已陣亡！【" + s1.Name + "】是獲勝者！！！");
                            break;
                        }
                    }
                    //戰士2開始攻擊

                    System.Threading.Thread.Sleep(1500);

                    if (r.Next(0, 101) < s1.Miss)
                    {
                        Console.WriteLine(s1.Name + "躲避了此次攻擊！！！");
                    }
                    else
                    {
                        if (r.Next(0, 101) < s1.block)
                        {
                            {
                                Console.WriteLine(s1.Name + "格擋了此次攻擊！！！");
                            }
                        }
                        else
                        {
                            int ss2 = r.Next(0, 100);

                            if (ss2 > 90)//開大招
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                Console.WriteLine("【" + s2.Name + "】對【" + s1.Name + "】釋放了★★★★★▄︻┻═┳一" + s2.Slay.Name + "★★★★★，造成" + s2.Slay.Attack + "點傷害，【" + s1.Name + "】剩餘" + (s1.Blood - s2.Slay.Attack) + "點血量");
                                Console.WriteLine();
                                //S2扣血
                                s1.Blood -= s2.Slay.Attack;
                            }
                            else if (ss2 >= 70 && ss2 <= 90)//開小招
                            {
                                int ss4 = r.Next(0, 100);
                                if (ss4 >= 0 && ss4 < 50)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    Console.WriteLine("【" + s2.Name + "】對【" + s1.Name + "】釋放了☆☆☆" + s2.Skill.Name + "☆☆☆，造成" + s2.Skill.Attack + "點傷害，【" + s1.Name + "】剩餘" + (s1.Blood - s2.Skill.Attack) + "點血量");
                                    Console.WriteLine();
                                    //S2扣血
                                    s1.Blood -= s2.Skill.Attack;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;

                                    Console.WriteLine("【" + s2.Name + "】對【" + s1.Name + "】釋放了☆☆☆" + s2.Skill1.Name1 + "☆☆☆，造成" + s2.Skill1.Attack1 + "點傷害，【" + s1.Name + "】剩餘" + (s1.Blood - s2.Skill1.Attack1) + "點血量");
                                    Console.WriteLine();
                                    //S2扣血
                                    s1.Blood -= s2.Skill.Attack;
                                }
                            }
                            else//普通攻擊
                            {
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("【" + s2.Name + "】攻擊了【" + s1.Name + "】，造成" + s2.Attack + "點傷害，【" + s1.Name + "】剩餘" + (s1.Blood - s2.Attack) + "點血量");
                                Console.WriteLine();
                                //S2扣血
                                s1.Blood -= s2.Attack;
                            }
                            if (s1.Blood <= 0)
                            {
                                Console.WriteLine("【" + s1.Name + "】已陣亡！【" + s2.Name + "】是獲勝者！！！");
                                break;
                            }
                        }
                    }
                }

                count++;
            }
            Console.ReadKey();
        }
    }
}

