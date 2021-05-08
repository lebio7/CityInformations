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

        public Style FrameStyle { get; private set; }

        public Style ImageStyle { get; private set; }

        public Style LabelStyleUnSelected { get; private set; }

        #endregion

        public SortButtonBuilder(Action<int> sortList)
        {
            sortButtonModel = new List<SortButtonModel>();
            FrameStyle = Helper.TryFindResource(Constants.ResourceNames.FrameSort);
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

                    frame.Style = FrameStyle;

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
                            SelectItem(sortButton, label);
                        }
                    });

                    frame.GestureRecognizers.Add(tapGestureRecognizer);
                    frame.Content = stackLayout;

                    if (sortButton.IdEnum == FirstSelectedItem)
                    {
                        SelectItem(sortButton, label);
                    }

                    baseLayout.Children.Add(frame);
                }
            }

        }

        private void SelectItem(SortButtonModel sortButton, Label label)
        {
            if (label != null && sortButton != null)
            {
                label.TextColor = SelectedColor;
                sortButton.IsSelected = true;
                selectedIdElement = sortButton.IdEnum;

                selectedItem = new Command(() =>
                {
                    UnSelectItem(sortButton, label);
                });

                SortList.Invoke(sortButton.IdEnum);
            }
        }

        private void UnSelectItem(SortButtonModel sortButton, Label label)
        {
            if (label != null && sortButton != null)
            {
                label.TextColor = UnSelectedColor;
                sortButton.IsSelected = false;
            }
        }

    }
}
