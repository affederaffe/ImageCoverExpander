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
            RectTransform rectTransform = _imageView.rectTransform;
            rectTransform.sizeDelta = new Vector2(60f, 60f);
            rectTransform.localPosition = new Vector3(-38.5f, -57f, 0f);
            Transform transform = _imageView.transform;
            transform.SetAsFirstSibling();
            transform.localScale = new Vector3(1.15f, 1f, 1f);
        }
    }
}