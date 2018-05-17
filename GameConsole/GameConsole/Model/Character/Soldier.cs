using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole.Model.Character
{
    public class Soldier
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //血量
        private int blood;

        public int Blood
        {
            get { return blood; }
            set { blood = value; }
        }
        //攻击力
        private int attack;

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        //技能
        private zhaoshi skill;

        public zhaoshi Skill
        {
            get { return skill; }
            set { skill = value; }
        }

        private zhaoshi skill1;

        public zhaoshi Skill1
        {
            get { return skill1; }
            set { skill1 = value; }
        }
        //必杀技
        private zhaoshi slay;

        internal zhaoshi Slay
        {
            get { return slay; }
            set { slay = value; }
        }
        //闪避
        private int miss;

        public int Miss
        {
            get { return miss; }
            set { miss = value; }
        }
        //暴击
        private int critical;

        public int Critical
        {
            get { return critical; }
            set { critical = value; }
        }
        //格挡
        private int Block;

        public int block
        {
            get { return Block; }
            set { Block = value; }
        }
    }

    public class zhaoshi
    {
        private string name;

        /// <summary>
        /// 招式名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string name1;

        /// <summary>
        /// 招式名称
        /// </summary>
        public string Name1
        {
            get { return name1; }
            set { name1 = value; }
        }

        private int attack;

        /// <summary>
        /// 招式攻击
        /// </summary>
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        private int attack1;

        /// <summary>
        /// 招式攻击
        /// </summary>
        public int Attack1
        {
            get { return attack1; }
            set { attack1 = value; }
        }


    }
}
