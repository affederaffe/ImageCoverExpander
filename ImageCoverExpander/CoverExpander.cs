using HMUI;

using ImageCoverExpander.Configuration;

using IPA.Utilities;

using UnityEngine;

using Zenject;


namespace ImageCoverExpander
{
    public sealed class CoverExpander : IInitializable
    {
        private readonly PluginConfig _config;
        private readonly StandardLevelDetailViewController _standardLevelDetailViewController;
        private readonly StandardLevelDetailView _standardLevelDetailView;
        private readonly ImageView _coverArtwork;

        public CoverExpander(PluginConfig config, StandardLevelDetailViewController standardLevelDetailViewController)
        {
            _config = config;
            _standardLevelDetailViewController = standardLevelDetailViewController;
            _standardLevelDetailView = standardLevelDetailViewController
                .GetField<StandardLevelDetailView, StandardLevelDetailViewController>("_standardLevelDetailView");
            _coverArtwork = _standardLevelDetailView
                .GetField<LevelBar, StandardLevelDetailView>("_levelBar")
                .GetField<ImageView, LevelBar>("_songArtworkImageView");
        }

        public void Initialize()
        {
            _standardLevelDetailViewController.didChangeContentEvent += OnDidChangeContent;
        }

        private void OnDidChangeContent(StandardLevelDetailViewController _1, StandardLevelDetailViewController.ContentType _2)
        {
            _standardLevelDetailViewController.didChangeContentEvent -= OnDidChangeContent;
            _coverArtwork.SetField("_gradient", true);
            _coverArtwork.SetField("_color0", _config.GradientColor0);
            _coverArtwork.SetField("_color1", _config.GradientColor1);
            RectTransform rectTransform = _coverArtwork.rectTransform;
            rectTransform.sizeDelta = new Vector2(60f, 60f);
            rectTransform.localPosition = new Vector3(-38.5f, -57f, 0f);
            Transform transform = _coverArtwork.transform;
            transform.SetAsFirstSibling();
            transform.localScale = new Vector3(1.15f, 1f, 1f);
            foreach (CurvedTextMeshPro text in _standardLevelDetailView.GetComponentsInChildren<CurvedTextMeshPro>())
                text.color = _config.TextColor;
        }
    }
}