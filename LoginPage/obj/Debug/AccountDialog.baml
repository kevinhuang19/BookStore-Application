   M S B A M L   `   `   `  ����G  CBookStoreGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BookStoreGUIBookStoreGUI  5           BookStoreGUI.AccountDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:BookStoreGUI     5      -   5          � Title$  
My Account��5	      $	��484��6   $	��550��6'   .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��
-6,0,0,397q�6I   $	��542��6]   .+�5      �� $��
From date:��6   $��10,0,0,0q�6)   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ fromDate��5      $��25��6+   67   �� 5      $��To date:��6   $��10,0,0,0q�6'     5      -   5        $ toDate��5      $��25��6)   65   �� 5      -   5         ��Name$ searchButton��5   2   $��Search��6   $��25��6&   $��75��5      $��28,2,0,0q�6   6$   �� 5      -   5        $ closeButton��5   1   $��Close��6   $��25��6%   $��75��5      $��35,2,0,0q�6   6$   5      �� 5   
   $ Vertical=�6   $��-6,36,6,-36q�6,   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ orderDataGrid��5         AutoGenerateColumns .  $	��193��5   3   $	��532��5      $
��Left=�6   $��
10,10,0,10q�6*      SelectionMode$ Single=�5      ��5      �� *	drOrder+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        orderIDColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Order ID��5       	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 5* 6   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5      �� *	OrderID+5         5!      -   5        orderDateColumn��$ 
Order date��5#      $		 18* 6   
 5"      �� *	OrderDate+5#        5$      -	   5        statusColumn��$ Status��5&      $		 10* 6      CanUserSort .  
 5%      �� *Status+5&         5'      -
   5        totalColumn��$ Total��5)      $		 15* 6   
 5(      �� *Total+5)      5+      5,      �� 5.   
   $ 
Horizontal=�6   $
��Left=�6.   $��26,256,0,178q�6I   .+�5/      �� $��PayPal Payment Methods:��6   $��31��67   $��	0,0,0,-12q�6C   50      �� 52   
   $ Vertical=�6   $��10,280,306,76q�6,   .+�53        -   5        $ PaypalMethodsGrid��53       . $
��Left=�6O   $��98��6k   $	��226��6w   54      �� 56   
   $ 
Horizontal=�6   $
��Left=�6.   $��286,256,0,178q�6I   .+�57      �� $��Card Payment Methods:��6   $��31��65   $��	0,0,0,-12q�6A   58      �� 5:   
   $ Vertical=�6   $��286,280,33,76q�6,   .+�5;        -   5        $ CardMethodsGrid��5;       . $
��Left=�6M   $��98��6i   $	��223��6u   5<      �� 5>   
   $ 
Horizontal=�6   $��Center=�6.   $��26,391,238,10q�6K   $	��278��6b   .+�5?      �� -   5        $ 
addPayment��5?      $��25��6)   $��80��68   $��
Add Method��6F   $��38��6t   $	��Top=�6�   $��95��6�   $��15, 0q�6�   �� 5@      -   5        $ removePayment��5@      $��25��6,   $��80��6;   $��Remove Method��6I   $	��Top=�6}   $��15,0,0,0q�6�   $	��110��6�   $��38��6�   5A      5C      5D      