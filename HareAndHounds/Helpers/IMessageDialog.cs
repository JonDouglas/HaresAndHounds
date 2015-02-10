using System;
using HareAndHounds.Models;

namespace HareAndHounds.Helpers
{
    public interface IMessageDialog
    {
        void SendToast(string toast);

        void SendMessage(string title, string message);

        void SendMessage(string title, string message, Action completed);

        void EnterTextMessage(string title, string message, Action<string> completed);

        void AskQuestions(string title, Question question, Action<int> completed);
    }
}
