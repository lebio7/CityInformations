using CityInformationsApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace CityInformationsApp.Utils
{
    public class SortButtonBuilder
    {
        #region Constants

        private const int FirstSelectedItem = 0;

        #endregion

        #region Members

        private Color SelectedColor = Color.Red;
        private Color UnSelectedColor = Color.White;

        private List<SortButtonModel> sortButtonModel;
        private int selectedIdElement;

        private ICommand selectedItem;
        private Action<int> SortList;
        #endregion

        #region Properties

        public Style FrameDefaultStyle { get; private set; }
        public Style FrameSelectedStyle { get; private set; }

        public Style ImageStyle { get; private set; }

        public Style LabelStyleUnSelected { get; private set; }

        #endregion

        public SortButtonBuilder(Action<int> sortList)
        {
            sortButtonModel = new List<SortButtonModel>();
            FrameDefaultStyle = Helper.TryFindResource(Constants.ResourceNames.FrameSort);
            FrameSelectedStyle = Helper.TryFindResource(Constants.ResourceNames.FrameSelectedSort);
            ImageStyle = Helper.TryFindResource(Constants.ResourceNames.ImageSort);
            LabelStyleUnSelected = Helper.TryFindResource(Constants.ResourceNames.LabelSortUnSelected);
            SortList = sortList;
        }

        public void AddButtonsByEvents(Enums.Events[] events)
        {
            if (events == null || events.Length == 0)
            {
                return;
            }

            for (int i = 0; i < events.Length; i++)
            {
                sortButtonModel.Add(new SortButtonModel(i, events[i].ToString(), Helper.GetImageForSortButtonEvent(events[i])));
            }
        }

        public void AddButtonsByObjectLocation(Enums.ObjectLocation[] objectlocations)
        {
            if (objectlocations == null || objectlocations.Length == 0)
            {
                return;
            }

            for (int i = 0; i < objectlocations.Length; i++)
            {
                sortButtonModel.Add(new SortButtonModel(i, objectlocations[i].ToString(), Helper.GetImageForSortButtonObjectLocation(objectlocations[i])));
            }
        }

        public void Build(FlexLayout baseLayout)
        {
            if (sortButtonModel?.Count > 0)
            {
                foreach (SortButtonModel sortButton in sortButtonModel)
                {
                    Frame frame = new Frame();

                    frame.Style = FrameDefaultStyle;

                    StackLayout stackLayout = new StackLayout();
                    stackLayout.VerticalOptions = LayoutOptions.Center;

                    Image image = new Image();
                    image.Source = sortButton.ImageSort;
                    image.Style = ImageStyle;

                    Label label = new Label();
                    label.Text = sortButton.Title;
                    label.Style = LabelStyleUnSelected;

                    stackLayout.Children.Add(image);
                    stackLayout.Children.Add(label);

                    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Command = new Command(() =>
                    {
                        if (label != null && sortButton != null)
                        {
                            if (sortButton.IdEnum == selectedIdElement)
                            {
                                return;
                            }

                            selectedItem?.Execute(null);
                            SelectItem(sortButton, frame);
                        }
                    });

                    frame.GestureRecognizers.Add(tapGestureRecognizer);
                    frame.Content = stackLayout;

                    if (sortButton.IdEnum == FirstSelectedItem)
                    {
                        SelectItem(sortButton, frame);
                    }

                    baseLayout.Children.Add(frame);
                }
            }

        }

        private void SelectItem(SortButtonModel sortButton, Frame tile)
        {
            if (tile != null && sortButton != null)
            {
                tile.Style = FrameSelectedStyle;
                sortButton.IsSelected = true;
                selectedIdElement = sortButton.IdEnum;

                selectedItem = new Command(() =>
                {
                    UnSelectItem(sortButton, tile);
                });

                SortList.Invoke(sortButton.IdEnum);
            }
        }

        private void UnSelectItem(SortButtonModel sortButton, Frame tile)
        {
            if (tile != null && sortButton != null)
            {
                tile.Style = FrameDefaultStyle;
                sortButton.IsSelected = false;
            }
        }

    }
}
