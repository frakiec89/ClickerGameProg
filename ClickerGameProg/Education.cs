namespace ClickerGameProg
{
    // track
    public  class Education : BaseObject
    {
        /// <summary>
        /// ступень образования
        /// </summary>
        public int  Lavel {  get; set; } 

        public  int  CountDAY { get; set; }
        public override string ToString()
        {
            return $"Образование пользователя {Name}: ";
        }
    }

    // todo добавить образование



}