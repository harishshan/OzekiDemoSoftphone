   M S B A M L   `   `   `  ����Q  MOzekiDemoSoftphoneWPF, Version=1.8.17.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:OzekiDemoSoftphoneWPF.GUI.Converters$OzekiDemoSoftphoneWPF.GUI.Converters  5   	   -    'OzekiDemoSoftphoneWPF.GUI.AccountWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Cconv2clr-namespace:OzekiDemoSoftphoneWPF.GUI.Converters     5   	     � Title$  SIP account settings��5   	   $	��502��6&   $	��330��63    � 
ResizeMode$ NoResize=�6?    � WindowStartupLocation$ CenterOwner=�6U    � WindowStyle$ 
ToolWindow=�6y    � DataContext 5   	   ��  �� RelativeSource �� *Self+ � 	Resources 5      ?  9OzekiDemoSoftphoneWPF.GUI.Converters.ReverseBoolConverter   ReverseBoolConverter��%   &	          5   
   6$   5	      .��5
      � .+�5   
   �� -   5        $��grpSIPAccount��5      $��SIP account settings��6(   $	��224��6F   $	��Top=�6S   $��	12,5,12,0q�6k   .��5      �  � RowDefinitions 5      �� 5      $��10 �6$   �� 5      $��26 �6$   �� 5      $��26 �6$   �� 5      $��26 �6$   �� 5      $��26 �6$   �� 5      $��26 �6$   �� 5      $��26 �6$   �� 5      $��26 �6$   �� 5      $��26 �6$   �� 5      $
��202* �6$    � ColumnDefinitions 5      �� 5      $	��120 �6'   �� 5      $
��158* �6'   .+�5      �� -   5        $��lDisplayName��5      $��Display name:��6,   $��1��6D   $��0��6Q   $��Right=�6a   $	��Top=�6}   $	��Top=�6�   �� 5      -   5        $��tbDisplayName��5      $��1��6/   $��1��6<   $
��Left=�6o   $��Center=�6�   $	��120��6�   ��6L   �� *Model.DisplayName+6�   �� 5       -   5        $��	lUserName��5       $��
User name:��6)   $��2��6>   $��0��6K   $��Right=�6[   $	��Top=�6w   $	��Top=�6�   �� 5!      -   5        $��
tbUserName��5!      $��2��6,   $��1��69   $
��Left=�6i   $��Center=�6�   $	��120��6�   ��6I   �� *Model.UserName+6�   �� 5#      -   5        $��lRegisterName��5#      $��Register name:��6-   $��3��6F   $��0��6S   $��Right=�6c   $	��Top=�6   $	��Top=�6�   �� 5$      -   5        $��tbRegisterName��5$      $��3��60   $��1��6=   $
��Left=�6r   $��Center=�6�   $	��120��6�   ��6M   �� *Model.RegisterName+6�   �� 5&      -   5        $��	lPassword��5&      $��	Password:��6)   $��4��6=   $��0��6J   $��Right=�6Z   $	��Top=�6v   $	��Top=�6�   �� 5'      -	   5        $��
tbPassword��5'      $��4��6,   $��1��69   $
��Left=�6i   $��Center=�6�   $	��120��6�   ��6I   �� *Model.Password+6�   �� 5)      -
   5        $��lDomain��5)      $��Domain:��6'   $��5��69   $��0��6F   $��Right=�6V   $	��Top=�6r   $	��Top=�6�   �� 5*      -   5        $��tbDomain��5*      $��5��6*   $��1��67   $
��Left=�6e   $��Center=�6�   $	��120��6�   ��6G   �� *Model.Domain+6�   �� 5,      -   5        $��lOutboundProxy��5,      $��Outbound Proxy:��6.   $��6��6H   $��0��6U   $��Right=�6e   $	��Top=�6�   $	��Top=�6�   �� 5-      -   5        $��tbOutboundProxy��5-      $��6��61   $��1��6>   $
��Left=�6s   $��Center=�6�   $	��120��6�   ��6N   �� *Model.OutboundProxy+6�   �� 5/      -   5        $��chkbRegRequired��5/      $��7��62   $��1��6?   $��Registration required��6�   $
��Left=�6�   $��Center=�6�   	 d� 	IsChecked	 6O   �� *Model.RegistrationRequired+6�   50      51      �� 52   
   -   5        $��grpNetworkSettings��52      $��Network settings��6-   $	��172��6G   $��12,235,12,0q�6T   $	��Top=�6j   .��53      �  54      �� 55      $��10 �6$   �� 56      $��26 �6$   �� 57      $��26 �6$   �� 58      $��26 �6$   �� 59      $��26 �6$   �� 5:      $��26 �6$    5<      �� 5=      $	��120 �6'   �� 5>      $
��158* �6'   .+�5@      �� -   5        $��lTransportType��5@      $��Transport type:��6.   $��1��6H   $��0��6U   $��Right=�6e   $	��Top=�6�   $	��Top=�6�   �� 5A      -   5        $��cbTransportType��5A      $��1��62   $��1��6?   $
��Left=�6�   $��Center=�6�   $��60��6�   ��6O   �� *TransportTypes+
 �� SelectedItem
 6v   �� *Model.TransportType+6�   �� 5C      -   5        $��	lSRTPMode��5C      $��
SRTP mode:��6)   $��2��6>   $��0��6K   $��Right=�6[   $	��Top=�6w   $	��Top=�6�   �� 5D      -   5        $��
cbSRTPMode��5D      $��2��6-   $��1��6:   $
��Left=�6�   $��Center=�6�   $��60��6�   ��6J   �� *	SRTPModes+
 6l   �� *Model.SRTPMode+6�   �� 5F      -   5        $��lAutoDetectNAT��5F      $��Auto-Detect NAT:��6.   $��3��6I   $��0��6V   $��Right=�6f   $	��Top=�6�   $	��Top=�6�   �� 5G      -   5        $��chkbAutoDetectNAT��5G      $��3��64   $��1��6A   $�� ��6{   $
��Left=�6�   $��Center=�6�   	 6Q   �� *Model.AutoDetectNat+6�   �� 5I      -   5        $��lNATTraversal��5I      $��NAT traversal:��6-   $��4��6F   $��0��6S   $��Right=�6c   $	��Top=�6   $	��Top=�6�   �� 5J      -   5        $��cbNATTraversal��5J      $��4��61   $��1��6>   $
��Left=�6"  $��Center=�6=  $	��120��6X  ��6N   �� *NatTraversalMethods+ �� SelectedIndex 6z   �� *Model.NatTraversalMethod+{�6�   ��  �� ElementName$ chkbAutoDetectNAT�� �� Path$ 	IsChecked� �� 	Converter# [  6X  �� 5L      -   5        $��lSTUNserver��5L      $��STUN server:��6+   $��5��6B   $��0��6O   $��Right=�6_   $	��Top=�6{   $	��Top=�6�   �� 5M      -   5        $��tbSTUNserver��5M      $��5��6.   $��1��6;   $
��Left=�6t   $��Center=�6�   $	��120��6�   ��6K   �� *Model.STUNServerAddress+6�   5N      5P      �� 5Q   
   -   5        $��btnOK��5Q      $��OK��6   $��23��6+   $
��Left=�67   $��
73,428,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 5R   
   -   5        $��	btnCancel��5R      $��Cancel��6"   $��23��63   $
��Left=�6?   $��154,428,0,0q�6Z   $	��Top=�6p   $��75��6�   6�   5S      5T      