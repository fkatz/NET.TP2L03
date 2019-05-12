﻿namespace Business.Entities
{
    public class BusinessEntity
    {
        public BusinessEntity()
        {
            State = States.New;
        }

        public int ID { get; set; }

        public enum States { New, Deleted, Modified, Unmodified }

        public States State { get; set; }


    }
}
