using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace gameExperiment.Managers
{
    public class UIEventHandler
    {
        #region Event Types Enumerator (Very C, I Like It)
        public enum EventType
        {
            PlayMusic,
            PauseMusic,
            EnterGameState,
            EnterPauseState,
            EnterSettingsMenu,
            ExitScreen,
            FlashMessage,
            QuitApplication 
        }
        #endregion

        public List<EventType> eventQueue { get; private set; }
        private int queueIndex;

        public string messageToSendForFlash { get; set; }
        public MessageBox flashMessageBox;

        public UIEventHandler(MessageBox flashMessageBox)
        {
            eventQueue = new List<EventType>();
            queueIndex = 0;
            this.flashMessageBox = flashMessageBox;
        }

        /// <summary>
        /// A switch statement to handle each specific event type
        ///
        /// </summary>
        /// <param name="currentEvent">The EventType you want to be handled</param>
        public void HandleEvent(EventType currentEvent)
        {
            switch (currentEvent)
            {
                // all these states need to be implemented as soon as i do proper UI manager code :p
                case EventType.PlayMusic: { return; }
                case EventType.PauseMusic: { return; }
                case EventType.FlashMessage: { flashMessageBox.DisplayMessage(messageToSendForFlash); return; }
                case EventType.EnterGameState: { return; }
                case EventType.EnterPauseState: { return; }
                case EventType.EnterSettingsMenu: { return; }
                case EventType.ExitScreen: { return; }
                case EventType.QuitApplication:
                    {
                        // REMEMBER TO ADD SAVESTATE CODE!!!
                        return;
                    }
                default: { return; }
            }
        }
        /// <summary>
        /// Loops through every event in the queue. Is this even necessary? Don't care.
        /// </summary>
        /// <param name="queue">The queue of EventTypes to be iterated</param>
        /// <param name="index">Just in case there are any problems with looping, save state and give it back as a parameter. Default is 0</param>
        public void IterateEvents(List<EventType> queue, int index=0)
        {
            if (index != 0)
            {
                HandleEvent(queue[index]);
                return;
            }
            else 
            { 
                for (int i = index; i<queue.Count; i++)
                {
                    HandleEvent(queue[i]);   
                }            
            }
            
        }
    }
}
