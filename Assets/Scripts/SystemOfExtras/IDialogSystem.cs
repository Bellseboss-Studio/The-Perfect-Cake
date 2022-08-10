﻿using Game.VisorDeDialogosSystem;

namespace SystemOfExtras
{
    public interface IDialogSystem
    {
        public void OpenDialog();
        public void NextDialog();
        public void OpenDialog(string idDialog);
        public void SelectOption(int keyPress);
        StatesOfDialogs GetState();
        void CloseDialog();
    }
}