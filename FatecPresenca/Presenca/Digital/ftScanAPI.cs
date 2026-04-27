using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Presenca
{
    public class ftScanAPI
    {
        // ============================================================================
        // CONFIGURATION
        // ============================================================================

        /// <summary>
        /// Name of the native DLL.  Update this if your DLL has a different name. 
        /// Common names:  "ftrScanAPI.dll", "ftrScanAPI64.dll", etc.
        /// </summary>
        private const string DllName = @"..\..\..\..\Presenca\Digital\ftrScanAPI.dll";

        // ============================================================================
        // CONSTANTS
        // ============================================================================

        // Basic max values
        public const int FTR_MAX_INTERFACE_NUMBER = 128;

        // Options flags
        public const uint FTR_OPTIONS_CHECK_FAKE_REPLICA = 0x00000001;
        public const uint FTR_OPTIONS_DETECT_FAKE_FINGER = 0x00000001;
        public const uint FTR_OPTIONS_FAST_FINGER_DETECT_METHOD = 0x00000002;
        public const uint FTR_OPTIONS_RECEIVE_LONG_IMAGE = 0x00000004;
        public const uint FTR_OPTIONS_RECEIVE_FAKE_IMAGE = 0x00000008;
        public const uint FTR_OPTIONS_SCALE_IMAGE = 0x00000010;
        public const uint FTR_OPTIONS_IMPROVE_IMAGE = 0x00000020;
        public const uint FTR_OPTIONS_INVERT_IMAGE = 0x00000040;
        public const uint FTR_OPTIONS_PREVIEW_MODE = 0x00000080;
        public const uint FTR_OPTIONS_IMAGE_FORMAT_MASK = 0x00000700;
        public const uint FTR_OPTIONS_IMAGE_FORMAT_1 = 0x00000100;
        public const uint FTR_OPTIONS_ELIMINATE_BACKGROUND = 0x00000800;
        public const uint FTR_OPTIONS_IMPROVE_BACKGROUND = 0x00001000;
        public const uint FTR_OPTIONS_ROLL_THRESHOLD_MASK = 0x001F0000;
        public const uint FTR_OPTIONS_ROLL_THRESHOLD_1 = 0x00010000;

        // Global options
        public const uint FTR_GLOBAL_ENABLE_REMOTE_SESSION_DETECTION = 0x00000001;
        public const uint FTR_GLOBAL_SYNC_DIR = 0x00000002;
        public const uint FTR_GLOBAL_USB_HOST_CONTEXT_VERSION = 0x00000003;
        public const uint FTR_GLOBAL_SAVE_SESSION_TO_FILE = 0x00000004;
        public const uint FTR_GLOBAL_DISABLE_ENCRYPTION = 0x00000006;

        public const uint FTR_GLOBAL_VALUE_REMOTE_SESSION_ENABLE = 0x00000001;
        public const uint FTR_GLOBAL_VALUE_REMOTE_SESSION_DISABLE = 0x00000000;
        public const uint FTR_GLOBAL_VALUE_USB_HOST_CONTEXT_VERSION_MAX = 0x00000002;

        // Light control
        public const byte FTR_LIGHT_NO_LIGHT = 0x00;
        public const byte FTR_LIGHT_MAIN_IFRED = 0x01;
        public const byte FTR_LIGHT_ADDITIONAL_IFRED = 0x02;
        public const byte FTR_LIGHT_BACK_IFRED = 0x04;
        public const byte FTR_LIGHT_GREEN = 0x08;

        /// <summary>
        /// Turn on a specific light by setting the high bit. 
        /// </summary>
        public static byte LightTurnOn(byte lightType) => (byte)(0x80 | lightType);

        /// <summary>
        /// Turn off a specific light by clearing the high bit.
        /// </summary>
        public static byte LightTurnOff(byte lightType) => (byte)(0x7F & lightType);

        // Pre-computed light states
        public static byte FTR_LIGHT_ON_MAIN_IFRED => LightTurnOn(FTR_LIGHT_MAIN_IFRED);
        public static byte FTR_LIGHT_ON_ADDITIONAL_IFRED => LightTurnOn(FTR_LIGHT_ADDITIONAL_IFRED);
        public static byte FTR_LIGHT_ON_BACK_IFRED => LightTurnOn(FTR_LIGHT_BACK_IFRED);
        public static byte FTR_LIGHT_ON_GREEN => LightTurnOn(FTR_LIGHT_GREEN);

        public static byte FTR_LIGHT_OFF_MAIN_IFRED => LightTurnOff(FTR_LIGHT_MAIN_IFRED);
        public static byte FTR_LIGHT_OFF_ADDITIONAL_IFRED => LightTurnOff(FTR_LIGHT_ADDITIONAL_IFRED);
        public static byte FTR_LIGHT_OFF_BACK_IFRED => LightTurnOff(FTR_LIGHT_BACK_IFRED);
        public static byte FTR_LIGHT_OFF_GREEN => LightTurnOff(FTR_LIGHT_GREEN);

        // Diode constants
        public const byte FTR_CONST_DIODE_OFF = 0;
        public const byte FTR_CONST_DIODE_ON = 255;

        // Error codes
        public const uint FTR_ERROR_NO_ERROR = 0;
        public const uint FTR_ERROR_EMPTY_FRAME = 4306;

        // FTR_ERROR_BASE = 0x20000000
        public const uint FTR_ERROR_MOVABLE_FINGER = 0x20000001;
        public const uint FTR_ERROR_NO_FRAME = 0x20000002;
        public const uint FTR_ERROR_USER_CANCELED = 0x20000003;
        public const uint FTR_ERROR_HARDWARE_INCOMPATIBLE = 0x20000004;
        public const uint FTR_ERROR_FIRMWARE_INCOMPATIBLE = 0x20000005;
        public const uint FTR_ERROR_INVALID_AUTHORIZATION_CODE = 0x20000006;
        public const uint FTR_ERROR_ROLL_NOT_STARTED = 0x20000007;
        public const uint FTR_ERROR_ROLL_PROGRESS_DATA = 0x20000008;
        public const uint FTR_ERROR_ROLL_TIMEOUT = 0x20000009;
        public const uint FTR_ERROR_ROLL_ABORTED = 0x2000000A;
        public const uint FTR_ERROR_ROLL_ALREADY_STARTED = 0x2000000B;
        public const uint FTR_ERROR_ROLL_PROGRESS_REMOVE_FINGER = 0x2000000C;
        public const uint FTR_ERROR_ROLL_PROGRESS_PUT_FINGER = 0x2000000D;
        public const uint FTR_ERROR_ROLL_PROGRESS_POST_PROCESSING = 0x2000000E;
        public const uint FTR_ERROR_FINGER_IS_PRESENT = 0x2000000F;
        public const uint FTR_ERROR_NULL_PARAMETER = 0x20000010;
        public const uint FTR_ERROR_LIBUSB_ERROR = 0x20000011;
        public const uint FTR_ERROR_VERSION_NOT_SUPPORTED = 0x20000012;
        public const uint FTR_ERROR_BAD_CALLBACK_FUNCTION = 0x20000013;

        // Windows error codes
        public const uint FTR_ERROR_NO_MORE_ITEMS = 259;
        public const uint FTR_ERROR_NOT_ENOUGH_MEMORY = 8;
        public const uint FTR_ERROR_NO_SYSTEM_RESOURCES = 1450;
        public const uint FTR_ERROR_TIMEOUT = 1460;
        public const uint FTR_ERROR_NOT_READY = 21;
        public const uint FTR_ERROR_BAD_CONFIGURATION = 1610;
        public const uint FTR_ERROR_INVALID_PARAMETER = 87;
        public const uint FTR_ERROR_CALL_NOT_IMPLEMENTED = 120;
        public const uint FTR_ERROR_NOT_SUPPORTED = 50;
        public const uint FTR_ERROR_WRITE_PROTECT = 19;
        public const uint FTR_ERROR_MESSAGE_EXCEEDS_MAX_SIZE = 4336;
        public const uint FTR_ERROR_PORT_UNREACHABLE = 1234;

        // Logging
        public const uint FTR_LOG_MASK_OFF = 0;
        public const uint FTR_LOG_MASK_TO_FILE = 0x00000001;
        public const uint FTR_LOG_MASK_TO_AUX = 0x00000002;
        public const uint FTR_LOG_MASK_TIMESTAMP = 0x00000004;
        public const uint FTR_LOG_MASK_THREAD_ID = 0x00000008;
        public const uint FTR_LOG_MASK_PROCESS_ID = 0x00000010;

        public const int FTR_LOG_LEVEL_MIN = 0;
        public const int FTR_LOG_LEVEL_OPTIMAL = 1;
        public const int FTR_LOG_LEVEL_FULL = 2;

        // Device types
        public const int FTR_DEVICE_USB_1_1 = 0;
        public const int FTR_DEVICE_USB_2_0_TYPE_1 = 1;
        public const int FTR_DEVICE_SWEEP = 2;
        public const int FTR_DEVICE_USB_2_0_TYPE_2 = 4;
        public const int FTR_DEVICE_USB_2_0_TYPE_3 = 5;
        public const int FTR_DEVICE_USB_2_0_TYPE_4 = 6;
        public const int FTR_DEVICE_USB_2_0_TYPE_50 = 7;
        public const int FTR_DEVICE_USB_2_0_TYPE_60 = 8;
        public const int FTR_DEVICE_USB_2_0_TYPE_25 = 9;
        public const int FTR_DEVICE_USB_2_0_TYPE_10 = 10;
        public const int FTR_DEVICE_USB_2_0_TYPE_80W = 11;
        public const int FTR_DEVICE_USB_2_0_TYPE_90B = 12;
        public const int FTR_DEVICE_USB_2_0_TYPE_80H = 13;
        public const int FTR_DEVICE_USB_2_0_TYPE_88H = 14;
        public const int FTR_DEVICE_USB_2_0_TYPE_64 = 15;
        public const int FTR_DEVICE_USB_2_0_TYPE_26E = 16;
        public const int FTR_DEVICE_USB_2_0_TYPE_98 = 210;

        public const int FTR_VERSION_UNKNOWN_VERSION = 0xFFFF;

        // Power events
        public const uint FTR_POWER_EVENT_SLEEP = 0x00000001;
        public const uint FTR_POWER_EVENT_SESSION_DISCONNECT = 0x00000002;
        public const uint FTR_POWER_EVENT_SESSION_LOGOFF = 0x00000004;
        public const uint FTR_POWER_EVENT_LOGGING_OFF = 0x00000008;
        public const uint FTR_POWER_EVENT_SHUTDOWN = 0x00000010;
        public const uint FTR_POWER_EVENT_LOCK = 0x00000020;
        public const uint FTR_POWER_EVENT_ALL = 0xFFFFFFFF;

        public const uint FTR_TIMEOUT_INFINITE = 0xFFFFFFFF;

        // Properties
        public const int FTR_PROPERTY_NUMBER_OF_IMAGE_SIZES = 1;
        public const int FTR_PROPERTY_LFD_LEVEL = 2;
        public const int FTR_PROPERTY_LFD_SW_1_CALCULATED_DATA = 3;
        public const int FTR_PROPERTY_LFD_SW_1_PARAM = 4;
        public const int FTR_PROPERTY_LFD_SW_1_RESERVED = 5;
        public const int FTR_PROPERTY_LFD_SW_2_CALCULATED_DATA = 6;
        public const int FTR_PROPERTY_LFD_SW_2_PARAM = 7;
        public const int FTR_PROPERTY_LFD_D_SW_2_CALCULATED_DATA = 8;
        public const int FTR_PROPERTY_ENCRYPTION = 9;

        // Roll constants
        public const int FTR_ROLL_DIRECTION_NOT_DEFINED = 0;
        public const int FTR_ROLL_DIRECTION_FROM_LEFT_TO_RIGHT = 1;
        public const int FTR_ROLL_DIRECTION_FROM_RIGHT_TO_LEFT = 2;

        public const uint FTR_ROLL_FRAME_PARAM_FLAG_NOT_CALIBRATED = 0x00000001;
        public const uint FTR_ROLL_FRAME_PARAM_FLAG_INDEX = 0x00000002;
        public const uint FTR_ROLL_FRAME_PARAM_FLAG_DOSE = 0x00000004;
        public const uint FTR_ROLL_FRAME_PARAM_FLAG_CONRAST = 0x00000008;

        public const uint FTR_ROLL_RESULT_OK = 0;
        public const uint FTR_ROLL_RESULT_REVERSE_ROLLING = 1;
        public const uint FTR_ROLL_RESULT_TOO_FAST_ROLLING = 2;
        public const uint FTR_ROLL_RESULT_SLIPPAGE_AREAS = 3;
        public const uint FTR_ROLL_RESULT_BREAK = 4;

        // Roll callback reasons
        public const uint FTR_ROLL_CB_REASON_PUT_FINGER = 0x00000001;
        public const uint FTR_ROLL_CB_REASON_REMOVE_FINGER = 0x00000002;
        public const uint FTR_ROLL_CB_REASON_PROCESSING = 0x00000003;
        public const uint FTR_ROLL_CB_REASON_BEFORE_POSTPROCESSING = 0x00000004;
        public const uint FTR_ROLL_CB_REASON_POSTPROCESSING = 0x00000005;
        public const uint FTR_ROLL_CB_REASON_AFTER_POSTPROCESSING = 0x00000006;
        public const uint FTR_ROLL_CB_REASON_STARTED = 0x00000007;
        public const uint FTR_ROLL_CB_REASON_ABORTED = 0x00000008;
        public const uint FTR_ROLL_CB_REASON_KEEP_EMPTY = 0x00000009;

        public const uint FTR_ROLL_CB_OPERATION_SET_DIODES_STATUS = 0x00000001;
        public const uint FTR_ROLL_CB_OPERATION_SET_GET_PIN_STATUS = 0x00000002;

        // LFD modes
        public const uint FTR_LFD_MODE_HW = 0x00000001;
        public const uint FTR_LFD_MODE_SW_1 = 0x00000002;
        public const uint FTR_LFD_MODE_SW_2 = 0x00000004;
        public const uint FTR_LFD_MODE_SW_1_MAX_STRENGTH = 9;
        public const uint FTR_LFD_MODE_SW_2_MOST_LIKELY_TO_BE_FAKE = 5;

        public const uint FTR_LFD_LEVEL_1 = FTR_LFD_MODE_HW;
        public const uint FTR_LFD_LEVEL_2 = (FTR_LFD_MODE_HW | FTR_LFD_MODE_SW_1);
        public const uint FTR_LFD_LEVEL_3 = (FTR_LFD_MODE_HW | FTR_LFD_MODE_SW_2);
        public const uint FTR_LFD_LEVEL_MAX = (FTR_LFD_MODE_HW | FTR_LFD_MODE_SW_1 | FTR_LFD_MODE_SW_2);

        // Scanner features
        public const int FTR_SCANNER_FEATURE_LFD = 1;
        public const int FTR_SCANNER_FEATURE_DIODES = 2;
        public const int FTR_SCANNER_FEATURE_GET_IMAGE2 = 3;
        public const int FTR_SCANNER_FEATURE_SERIAL_NUMBER = 4;
        public const int FTR_SCANNER_FEATURE_LONG_IMAGE = 5;
        public const int FTR_SCANNER_FEATURE_IS_CALIBRATED = 6;
        public const int FTR_SCANNER_FEATURE_IS_LFD_CALIBRATED = 7;
        public const int FTR_SCANNER_FEATURE_ROLL = 8;
        public const int FTR_SCANNER_FEATURE_ENCRYPTION = 9;

        public const int FTR_BLACKFIN_MAX_WRITE_DATA_LEN = 4096;

        // ============================================================================
        // ENUMS & DELEGATES
        // ============================================================================

        /// <summary>
        /// Interface connection status. 
        /// </summary>
        public enum InterfaceStatus : int
        {
            Connected = 0,
            Disconnected = 1
        }

        /// <summary>
        /// Callback delegate for roll scanning operations.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int RollCallbackDelegate(IntPtr userContext, uint callbackReason, IntPtr ftrContext, IntPtr reasonContext);

        // ============================================================================
        // STRUCTURES (Marshalling Info)
        // ============================================================================

        /// <summary>
        /// Device information. 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DeviceInfo
        {
            public uint StructSize;
            public byte DeviceCompatibility;
            public ushort PixelSizeX;
            public ushort PixelSizeY;
        }

        /// <summary>
        /// Image dimensions and size.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ImageSize
        {
            public int Width;
            public int Height;
            public int ImageS;
        }

        /// <summary>
        /// Fake replica detection parameters.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FakeReplicaParameters
        {
            public int Calculated;
            public int CalculatedSum1;
            public int CalculatedSumFuzzy;
            public int CalculatedSumEmpty;
            public int CalculatedSum2;
            public double CalculatedTremor;
            public double CalculatedValue;
        }

        /// <summary>
        /// Fake replica buffer for advanced analysis.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FakeReplicaBuffer
        {
            public int Calculated;
            public int Buffers;
            public int Width;
            public int Height;
            public int Size;
            public IntPtr BuffersPtr;
        }

        /// <summary>
        /// LFD (Liveness/Fake Detection) constants.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LfdConstants
        {
            public int LMin;
            public int LMax;
            public int CMin;
            public int CMax;
            public int EEMin;
            public int EEMax;
        }

        /// <summary>
        /// Frame parameters for scan operations.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FrameParameters
        {
            public int ContrastOnDose2;
            public int ContrastOnDose4;
            public int Dose;
            public int BrightnessOnDose1;
            public int BrightnessOnDose2;
            public int BrightnessOnDose3;
            public int BrightnessOnDose4;
            public FakeReplicaParameters FakeReplicaParams;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
            public byte[] Reserved;
        }

        /// <summary>
        /// Interface list containing status of all interfaces.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct InterfacesList
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = FTR_MAX_INTERFACE_NUMBER)]
            public InterfaceStatus[] InterfaceStatus;
        }

        /// <summary>
        /// Version information (hi/lo components).
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Version
        {
            public ushort MajorVersionHi;
            public ushort MajorVersionLo;
            public ushort MinorVersionHi;
            public ushort MinorVersionLo;
        }

        /// <summary>
        /// Complete version information (API, hardware, firmware).
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct VersionInfo
        {
            public uint VersionInfoSize;
            public Version APIVersion;
            public Version HardwareVersion;
            public Version FirmwareVersion;
        }

        /// <summary>
        /// Extra parameters for variable dose operations.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct VarDoseExtraParams
        {
            public byte NumberOfFramesMinusOne;
            public byte Reserved1;
            public byte Reserved2;
            public byte Reserved3;
            public byte Reserved4;
        }

        /// <summary>
        /// Command packet for pipe communication.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PipeCommandPacket
        {
            public uint Label;
            public uint InDataSize;
            public uint WaitDataSize;
            public uint OperationStatus;
        }

        /// <summary>
        /// LFD level property.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PropertyLfdLevel
        {
            public uint LfdLevel;
        }

        /// <summary>
        /// LFD software 1 calculated data.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PropertyLfdSw1Data
        {
            public uint Strength;
        }

        /// <summary>
        /// LFD software 1 parameters.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PropertyLfdSw1Param
        {
            public uint Strength;
        }

        /// <summary>
        /// LFD software 2 calculated data (score-based).
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PropertyLfdSw2Data
        {
            public uint Score;
        }

        /// <summary>
        /// LFD software 2 parameters. 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PropertyLfdSw2Param
        {
            public uint Score;
        }

        /// <summary>
        /// Encryption property.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PropertyEncryption
        {
            public int Enabled;
        }

        /// <summary>
        /// Roll frame parameters for detailed frame info.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RollFrameParameters
        {
            public uint Size;
            public uint Flags;
            public uint Status;
            public uint RollingResult;
            public uint Direction;
            public uint FrameIndex;
            public uint FrameDose;
            public uint FrameContrast;
            public uint FrameTimeMs;
        }

        /// <summary>
        /// Diode status for roll operations.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RollCbOperationDiodesStatus
        {
            public byte GreenDiodeStatus;
            public byte RedDiodeStatus;
        }

        /// <summary>
        /// Pin flag status for roll operations.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RollCbOperationPfStatus
        {
            public uint Flags;
            public uint ToggleSet;
            public uint Period;
            public uint SetFlag;
        }

        /// <summary>
        /// Simulator context for device simulation.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SimulatorContext
        {
            public uint Size;
            public IntPtr OpenDevicePtr;
            public IntPtr CloseDevicePtr;
            public IntPtr DeviceDataExchangePtr;
            public IntPtr DeviceDataExchangeEndPtr;
            public IntPtr DeviceGetInfoPtr;
        }

        // ============================================================================
        // P/INVOKE FUNCTION DECLARATIONS
        // ============================================================================

        #region Device Management

        /// <summary>
        /// Opens the default scanner device.
        /// Returns a handle to the device, or IntPtr.Zero on failure.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr ftrScanOpenDevice();

        /// <summary>
        /// Opens a scanner device on a specific interface.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr ftrScanOpenDeviceOnInterface(int interfaceNumber);

        /// <summary>
        /// Opens a scanner device with an I/O context (advanced).
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr ftrScanOpenDeviceWithIoContext(IntPtr ioContext);

        /// <summary>
        /// Closes a scanner device handle.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void ftrScanCloseDevice(IntPtr deviceHandle);

        #endregion

        #region Options & Configuration

        /// <summary>
        /// Sets scanner options.  dwMask specifies which options to change, dwFlags specifies the new values.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanSetOptions(IntPtr deviceHandle, uint optionMask, uint optionFlags);

        /// <summary>
        /// Gets current scanner options. 
        /// Returns non-zero on success, fills lpdwFlags with current options.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetOptions(IntPtr deviceHandle, out uint optionFlags);

        /// <summary>
        /// Gets device information (compatibility, pixel size, etc.).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetDeviceInfo(IntPtr deviceHandle, ref DeviceInfo deviceInfo);

        #endregion

        #region Interface Management

        /// <summary>
        /// Gets list of all available scanner interfaces and their connection status.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetInterfaces(out InterfacesList interfaceList);

        /// <summary>
        /// Sets the base interface number for device enumeration.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrSetBaseInterface(int baseInterfaceNumber);

        /// <summary>
        /// Gets the current base interface number.
        /// Returns the interface number. 
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)]
        public static extern int ftrGetBaseInterfaceNumber();

        #endregion

        #region Logging & Error Handling

        /// <summary>
        /// Sets up logging facilities (file, aux, timestamps, etc.).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int ftrSetLoggingFacilityLevel(uint logMask, uint logLevel, string logFileName);

        /// <summary>
        /// Gets the last error code from the API. 
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)]
        public static extern uint ftrScanGetLastError();

        /// <summary>
        /// Manually sets the last error code.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void ftrScanSetLastError(uint errorCode);

        #endregion

        #region Version & Feature Information

        /// <summary>
        /// Gets version information (API, hardware, firmware).
        /// Returns non-zero on success. 
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetVersion(IntPtr deviceHandle, ref VersionInfo versionInfo);

        /// <summary>
        /// Checks if the scanner supports a specific feature.
        /// Returns non-zero on success, isPresent is set to non-zero if feature is present.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanIsScannerFeaturePresent(IntPtr deviceHandle, int featureCode, out int isPresent);

        #endregion

        #region Fake/Replica Detection

        /// <summary>
        /// Gets the interval range for fake replica detection.
        /// Returns non-zero on success. 
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetFakeReplicaInterval(out double minValue, out double maxValue);

        /// <summary>
        /// Sets the interval range for fake replica detection. 
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void ftrScanSetFakeReplicaInterval(double minValue, double maxValue);

        /// <summary>
        /// Gets LFD (Liveness/Fake Detection) parameters.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetLFDParameters(out LfdConstants lfdParams);

        /// <summary>
        /// Sets LFD (Liveness/Fake Detection) parameters.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanSetLFDParameters(ref LfdConstants lfdParams);

        /// <summary>
        /// Gets fake replica parameters from last scan.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetFakeReplicaParameters(IntPtr deviceHandle, out FakeReplicaParameters fakeReplicaParams);

        /// <summary>
        /// Gets fake replica buffer for detailed analysis.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetFakeReplicaBuffer(IntPtr deviceHandle, out FakeReplicaBuffer fakeReplicaBuffer);

        #endregion

        #region Image Scanning

        /// <summary>
        /// Gets the size of the image that will be returned by scan operations.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetImageSize(IntPtr deviceHandle, out ImageSize imageSize);

        /// <summary>
        /// Gets a raw fingerprint image with specified dose level. 
        /// pBuffer must be pre-allocated to imageSize. ImageSize bytes.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetImage(IntPtr deviceHandle, int dose, IntPtr imageBuffer);

        /// <summary>
        /// Gets an improved fingerprint image (version 2).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetImage2(IntPtr deviceHandle, int dose, IntPtr imageBuffer);

        /// <summary>
        /// Gets a fuzzy image for fake detection analysis.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetFuzzyImage(IntPtr deviceHandle, IntPtr imageBuffer);

        /// <summary>
        /// Gets a backlight image. 
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetBacklightImage(IntPtr deviceHandle, IntPtr imageBuffer);

        /// <summary>
        /// Gets a dark image (no illumination).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetDarkImage(IntPtr deviceHandle, IntPtr imageBuffer);

        /// <summary>
        /// Gets an image with variable dose (0-15).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetImageByVariableDose(IntPtr deviceHandle, int variableDose, IntPtr imageBuffer);

        /// <summary>
        /// Gets a 4-in-1 composite image (multiple exposures/angles).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGet4in1Image(IntPtr deviceHandle, IntPtr imageBuffer);

        /// <summary>
        /// Gets an image with variable dose and light control.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetImageByVariableDoseEx(IntPtr deviceHandle, int variableDose, byte lights, ref VarDoseExtraParams extraParams, IntPtr imageBuffer);

        /// <summary>
        /// Gets the raw (unprocessed) image size.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetRawImageSize(IntPtr deviceHandle, out ImageSize imageSize);

        /// <summary>
        /// Gets a raw image with variable dose.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetRawImageByVariableDose(IntPtr deviceHandle, int variableDose, IntPtr imageBuffer);

        /// <summary>
        /// Gets a raw backlight image.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetRawBacklightImage(IntPtr deviceHandle, IntPtr imageBuffer);

        /// <summary>
        /// Gets a raw dark image. 
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetRawDarkImage(IntPtr deviceHandle, IntPtr imageBuffer);

        #endregion

        #region Frame & Finger Detection

        /// <summary>
        /// Checks if a finger is currently present on the scanner. 
        /// Returns non-zero if finger is present, fills frameParameters with frame info.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanIsFingerPresent(IntPtr deviceHandle, out FrameParameters frameParameters);

        /// <summary>
        /// Gets the current frame (raw frame data).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetFrame(IntPtr deviceHandle, IntPtr frameBuffer, out FrameParameters frameParameters);

        #endregion

        #region Memory Operations

        /// <summary>
        /// Saves 7 bytes of device memory to buffer.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanSave7Bytes(IntPtr deviceHandle, IntPtr buffer);

        /// <summary>
        /// Restores 7 bytes of device memory from buffer.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRestore7Bytes(IntPtr deviceHandle, IntPtr buffer);

        /// <summary>
        /// Gets the size of external memory on the device.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetExtMemorySize(IntPtr deviceHandle, out int memorySize);

        /// <summary>
        /// Reads from external device memory.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanSaveExtMemory(IntPtr deviceHandle, IntPtr buffer, int offset, int count);

        /// <summary>
        /// Writes to external device memory.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRestoreExtMemory(IntPtr deviceHandle, IntPtr buffer, int offset, int count);

        #endregion

        #region Serial Number & Identification

        /// <summary>
        /// Gets the device serial number.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetSerialNumber(IntPtr deviceHandle, IntPtr serialBuffer);

        /// <summary>
        /// Saves the device serial number.
        /// Returns non-zero on success. 
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanSaveSerialNumber(IntPtr deviceHandle, IntPtr reserved);

        #endregion

        #region Firmware Operations

        /// <summary>
        /// Gets the size of firmware memory on the device.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetFirmwareMemorySize(IntPtr deviceHandle, out int memorySize);

        /// <summary>
        /// Reads firmware memory from the device.
        /// Returns non-zero on success. 
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanSaveFirmwareMemory(IntPtr deviceHandle, IntPtr buffer, int offset, int count);

        /// <summary>
        /// Writes firmware memory to the device. 
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRestoreFirmwareMemory(IntPtr deviceHandle, IntPtr buffer, int offset, int count);

        #endregion

        #region Calibration & System Control

        /// <summary>
        /// Gets IR and fuzzy image calibration constants.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetCalibrationConstants(IntPtr deviceHandle, IntPtr irConstBuffer, IntPtr fuzzyConstBuffer);

        /// <summary>
        /// Sets IR and fuzzy image calibration constants. 
        /// If bBurnToFlash is non-zero, writes to persistent storage.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanStoreCalibrationConstants(IntPtr deviceHandle, byte irConst, byte fuzzyConst, int burnToFlash);

        #endregion

        #region Authorization & Security

        /// <summary>
        /// Sets a new authorization code (7 bytes).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanSetNewAuthorizationCode(IntPtr deviceHandle, IntPtr authorizationCode);

        /// <summary>
        /// Saves secret 7 bytes encrypted. 
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanSaveSecret7Bytes(IntPtr deviceHandle, IntPtr authorizationCode, IntPtr buffer);

        /// <summary>
        /// Restores secret 7 bytes decrypted.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRestoreSecret7Bytes(IntPtr deviceHandle, IntPtr authorizationCode, IntPtr buffer);

        /// <summary>
        /// Sets control byte 7 values (system control flags).
        /// If bBurnToFlash is non-zero, writes to persistent storage. 
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanSave7ControlBytes(IntPtr deviceHandle, IntPtr buffer, int burnToFlash);

        /// <summary>
        /// Restores control byte 7 values. 
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRestore7ControlBytes(IntPtr deviceHandle, IntPtr buffer);

        #endregion

        #region Diode Control

        /// <summary>
        /// Sets the status of green and red indicator diodes.
        /// Use FTR_CONST_DIODE_ON (255) or FTR_CONST_DIODE_OFF (0).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanSetDiodesStatus(IntPtr deviceHandle, byte greenDiodeStatus, byte redDiodeStatus);

        /// <summary>
        /// Gets the current status of green and red indicator diodes.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetDiodesStatus(IntPtr deviceHandle, out int greenDiodeOn, out int redDiodeOn);

        #endregion

        #region Roll Scanning

        /// <summary>
        /// Starts a standard roll scan operation.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRollStart(IntPtr deviceHandle);

        /// <summary>
        /// Starts a roll scan with variable dose control.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRollStarWithVariableDose(IntPtr deviceHandle, int variableDose);

        /// <summary>
        /// Starts a raw (unprocessed) roll scan operation.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRollRawStart(IntPtr deviceHandle);

        /// <summary>
        /// Starts a raw roll scan with variable dose control.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRollRawStarWithVariableDose(IntPtr deviceHandle, int variableDose);

        /// <summary>
        /// Aborts an active roll scan operation.
        /// If bSynchronous is non-zero, waits for the operation to abort before returning.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRollAbort(IntPtr deviceHandle, int synchronous);

        /// <summary>
        /// Gets the current roll scan image.
        /// dwMilliseconds is the timeout in milliseconds (use FTR_TIMEOUT_INFINITE to wait forever).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRollGetImage(IntPtr deviceHandle, IntPtr imageBuffer, uint timeoutMs);

        /// <summary>
        /// Gets detailed frame parameters during a roll scan.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRollGetFrameParameters(IntPtr deviceHandle, out RollFrameParameters frameParameters, IntPtr frameBuffer, uint timeoutMs);

        /// <summary>
        /// Sets a callback function to monitor roll scan progress.
        /// The callback will be invoked at various stages of the scan. 
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRollSetCallBackFn(IntPtr deviceHandle, RollCallbackDelegate callbackFunction, IntPtr userContext);

        /// <summary>
        /// Performs an operation from within a roll scan callback.
        /// Returns non-zero on success. 
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanRollDoOperationFromCb(IntPtr ftrContext, uint rollCbOperation, IntPtr rollCbOperationParam);

        #endregion

        #region System Notifications & Global Options

        /// <summary>
        /// Registers power/system event notifications.
        /// dwMask specifies which events to monitor, dwFlags specifies desired behavior.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanChangeSystemNotification(uint eventMask, uint eventFlags);

        /// <summary>
        /// Sets a global API option (affects all devices).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGlobalSetOptions(uint option, IntPtr optionData);

        /// <summary>
        /// Gets a global API option value.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGlobalGetOptions(uint option, IntPtr optionData);

        #endregion

        #region Advanced Image Operations

        /// <summary>
        /// Gets a strip image (partial scan result).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetStripImageSize(IntPtr deviceHandle, out ImageSize imageSize);

        /// <summary>
        /// Gets strip image data with variable dose.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetStripImageByVariableDose(IntPtr deviceHandle, int variableDose, IntPtr imageBuffer);

        /// <summary>
        /// Gets registry values from the device.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetRegistryValues(IntPtr deviceHandle, IntPtr registryBuffer);

        /// <summary>
        /// Converts a raw image to final (processed) image with specified dose. 
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanConvertRawToFinalImage(IntPtr deviceHandle, IntPtr rawImageBuffer, IntPtr finalImageBuffer, int dose);

        /// <summary>
        /// Gets image of a specific size and position.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetImageOfSpecificSize(IntPtr deviceHandle, int variableDose, byte lights, int width, int height, IntPtr imageBuffer);

        /// <summary>
        /// Gets image of specific size with extra parameters (frame count).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetImageOfSpecificSizeEx(IntPtr deviceHandle, int variableDose, byte lights, int width, int height, int frameCount, IntPtr imageBuffer);

        /// <summary>
        /// Gets image of specific size with offset (advanced positioning).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetImageOfSpecificSize2(IntPtr deviceHandle, int variableDose, byte lights, int width, int height, int frameCount, int offsetX, int offsetY, IntPtr imageBuffer);

        #endregion

        #region Property Management

        /// <summary>
        /// Gets a device property value.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetProperty(IntPtr deviceHandle, int propertyCode, IntPtr propertyData);

        /// <summary>
        /// Sets a device property value. 
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanSetProperty(IntPtr deviceHandle, int propertyCode, IntPtr propertyData);

        /// <summary>
        /// Gets the size (in bytes) of a device property. 
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetPropertySize(IntPtr deviceHandle, int propertyCode, out uint propertySize);

        /// <summary>
        /// Gets all available image sizes supported by the device.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetImageSizes(IntPtr deviceHandle, IntPtr imageSizeArray);

        #endregion

        #region Sweep Scanner Operations (specific device type)

        /// <summary>
        /// Gets a single slice from a sweep scanner.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrSweepGetSlice(IntPtr deviceHandle, IntPtr sliceBuffer);

        /// <summary>
        /// Gets multiple slices from a sweep scanner.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrSweepGetMultipleSlices(IntPtr deviceHandle, int sliceCount, IntPtr sliceBuffer);

        #endregion

        #region Blackfin & Low-Level I/O

        /// <summary>
        /// Performs raw data exchange with Blackfin processor devices.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrBlackfinDataExchange(IntPtr deviceHandle, IntPtr writeBuffer, int writeBufferLength, IntPtr readBuffer, int readBufferLength);

        /// <summary>
        /// Controls pin 3 on the device.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanControlPin3(IntPtr deviceHandle, ref uint param1, uint param2, uint period);

        /// <summary>
        /// Gets the current button state.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanGetButtonState(IntPtr deviceHandle, ref uint buttonState);

        /// <summary>
        /// Controls main LED timeout behavior.
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrScanMainLEDsTimeout(IntPtr deviceHandle, ref uint param1, byte flag);

        /// <summary>
        /// Performs internal device I/O exchange (low-level).
        /// Returns non-zero on success.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ftrInternalDeviceIoExchange(IntPtr deviceHandle, IntPtr dataBuffer);

        #endregion

        #region Global Settings

        /// <summary>
        /// Sets global device synchronization mode.
        /// If fSet is non-zero, enables sync; otherwise disables. 
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void ftrSetGlobalDeviceSync(int enableSync);

        #endregion

        #region Simulator Support

        /// <summary>
        /// Opens a device using a simulator context (for testing/development).
        /// Returns a handle to the simulated device, or IntPtr.Zero on failure.
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr ftrScanOpenDeviceWithSimContext(ref SimulatorContext simContext);

        #endregion

        // ============================================================================
        // HELPER METHODS (High-level wrappers)
        // ============================================================================

        /// <summary>
        /// Opens a scanner device and returns a managed handle.
    }
}
