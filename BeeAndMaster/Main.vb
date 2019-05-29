Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Windows.Forms

Public Class Plugin
    Private mbApiInterface As New MusicBeeApiInterface
    Private about As New PluginInfo



    Public Function Initialise(ByVal apiInterfacePtr As IntPtr) As PluginInfo
        about.PluginInfoVersion = PluginInfoVersion
        about.Name = "BeeToLyricsMaster"
        about.Description = "A brief description of what this plugin does"
        about.Author = "Author"
        about.TargetApplication = "Yahoo Messenger"  ' current only applies to artwork, lyrics or instant messenger name that appears in the provider drop down selector or target Instant Messenger
        about.Type = PluginType.General
        about.VersionMajor = 1  ' your plugin version
        about.VersionMinor = 0
        about.Revision = 1
        about.MinInterfaceVersion = MinInterfaceVersion
        about.MinApiRevision = MinApiRevision
        about.ReceiveNotifications = ReceiveNotificationFlags.PlayerEvents
        about.ConfigurationPanelHeight = 0  ' height in pixels that musicbee should reserve in a panel for config settings. When set, a handle to an empty panel will be passed to the Configure function
        Return about

    End Function

    Public Sub ReceiveNotification(ByVal sourceFileUrl As String, ByVal type As NotificationType)

        Select Case type
            Case NotificationType.PluginStartup
                'プラグインの初期化処理をここに記述
                Dim mainMenuItem As ToolStripMenuItem = mbApiInterface.MB_AddMenuItem("context.Main/MenuItem Name Displayed", Nothing, Nothing)

            Case NotificationType.TrackChanged
                '曲が変わったときの動作
                'mbApiInterface.Playlist_CreatePlaylist("", "hello", New String() {mbApiInterface.NowPlaying_GetFileUrl()})


        End Select
    End Sub

    Public Sub mainMenuItem_click()
        If mbApiInterface.Library_QueryFiles("domain=SelectedFiles") Then
            Dim Filename As String = mbApiInterface.Library_QueryGetNextFile()

            Dim artist As String = mbApiInterface.Library_GetFileTag(Filename, MetaDataType.Artist)
            Dim tracktitle As String = mbApiInterface.Library_GetFileTag(Filename, MetaDataType.TrackTitle)


        End If
    End Sub

End Class
