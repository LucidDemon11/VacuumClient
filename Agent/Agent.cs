namespace IntelligentVacuum.Agent
{
    using System;
    using System.Collections.Generic;
    using Environments;

    public class Agent
    {
        public Agent()
        {
        }

        public AgentAction DecideAction(Room room)
        {
            AgentAction action;
            if (room.IsDirty) {
                action = AgentAction.CLEAN;
            }
            else 
            {
                action = DecideNextMove(room);
            }

            return action;
        }

        public AgentAction DecideNextMove(Room room)
        {
            AgentAction action = new AgentAction();
            Random numGen = new Random();
            int nextMove;

            while (true)
            {
                //Randomize next move
                nextMove = numGen.Next(1, 5);
                //1 = Up
                //2 = Right
                //3 = Down
                //4 = Left

                //If against the left wall
                if(room.XAxis == 0 && nextMove == 1)
                {
                    //Skip to next number
                    continue;
                }
                
                //If against the top wall
                if(room.YAxis == 0 && nextMove == 4)
                {
                    //Skip to next number
                    continue;
                }

                //Check number and set action
                if (nextMove == 1)
                    action = AgentAction.MOVE_UP;
                else if (nextMove == 2)
                    action = AgentAction.MOVE_RIGHT;
                else if (nextMove == 3)
                    action = AgentAction.MOVE_DOWN;
                else if (nextMove == 4)
                    action = AgentAction.MOVE_LEFT;

                //Exit loop
                break;
            }

            return action;
        }
    }
}