using HMUI;

using IPA.Utilities;

using UnityEngine;

using Zenject;


namespace ImageCoverExpander
{
    public sealed class CoverExpander : IInitializable
    {
        private readonly StandardLevelDetailViewController _standardLevelDetailViewController;
        private readonly ImageView _imageView;

        public CoverExpander(StandardLevelDetailViewController standardLevelDetailViewController)
        {
            _standardLevelDetailViewController = standardLevelDetailViewController;
            _imageView = standardLevelDetailViewController
                .GetField<StandardLevelDetailView, StandardLevelDetailViewController>("_standardLevelDetailView")
                .GetField<LevelBar, StandardLevelDetailView>("_levelBar")
                .GetField<ImageView, LevelBar>("_songArtworkImageView");
        }

        public void Initialize()
        {
            _standardLevelDetailViewController.didChangeContentEvent += OnDidChangeContentEvent;
        }

        private void OnDidChangeContentEvent(StandardLevelDetailViewController _1, StandardLevelDetailViewController.ContentType _2)
        {
            _standardLevelDetailViewController.didChangeContentEvent -= OnDidChangeContentEvent;
            _imageView.SetField("_gradient", true);
            _imageView.SetField("_color0", new Color(0.85f, 0.85f, 0.85f, 1f));
            _imageView.SetField("_color1", new Color(0.4f, 0.4f, 0.4f, 1f));
            _imageView.transform.SetAsFirstSibling();
            RectTransform rectTransform = _imageView.rectTransform;
            rectTransform.sizeDelta = new Vector2(75f, 75f);
            rectTransform.localPosition = new Vector3(-40f, -57.5f, 0f);
        }
    }
}