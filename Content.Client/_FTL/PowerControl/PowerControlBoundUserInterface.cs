using Content.Shared._FTL.PowerControl;
using Content.Shared.Gravity;
using JetBrains.Annotations;
using Robust.Client.GameObjects;

namespace Content.Client._FTL.PowerControl
{
    [UsedImplicitly]
    public sealed class PowerControlBoundUserInterface : BoundUserInterface
    {
        private PowerControlWindow? _window;

        public PowerControlBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey) { }

        protected override void Open()
        {
            base.Open();

            _window = new PowerControlWindow(this, Owner);

            _window.OpenCentered();
            _window.OnClose += Close;
        }

        public void ToggleApc(NetEntity entity)
        {
            SendMessage(new ToggleApcMessage(entity));
        }

        protected override void UpdateState(BoundUserInterfaceState state)
        {
            base.UpdateState(state);

            var castState = (PowerControlState) state;
            _window?.UpdateState(castState);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;

            _window?.Dispose();
        }
    }
}
