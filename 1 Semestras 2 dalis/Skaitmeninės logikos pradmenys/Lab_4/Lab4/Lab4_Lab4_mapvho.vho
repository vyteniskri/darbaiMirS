
-- VHDL netlist produced by program ldbanno, Version Diamond (64-bit) 3.12.0.240.2

-- ldbanno -n VHDL -o Lab4_Lab4_mapvho.vho -w -neg -gui -msgset C:/Users/Labas/Desktop/Skaitmenine logika/Lab_4/promote.xml Lab4_Lab4_map.ncd 
-- Netlist created on Tue May 17 01:09:31 2022
-- Netlist written on Tue May 17 01:11:28 2022
-- Design is for device LFXP2-5E
-- Design is for package TQFP144
-- Design is for performance grade 6

-- entity ec2iobuf
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity ec2iobuf is
    port (I: in Std_logic; T: in Std_logic; PAD: out Std_logic);

    ATTRIBUTE Vital_Level0 OF ec2iobuf : ENTITY IS TRUE;

  end ec2iobuf;

  architecture Structure of ec2iobuf is
    component OBZPU
      port (I: in Std_logic; T: in Std_logic; O: out Std_logic);
    end component;
  begin
    INST5: OBZPU
      port map (I=>I, T=>T, O=>PAD);
  end Structure;

-- entity gnd
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity gnd is
    port (PWR0: out Std_logic);

    ATTRIBUTE Vital_Level0 OF gnd : ENTITY IS TRUE;

  end gnd;

  architecture Structure of gnd is
    component VLO
      port (Z: out Std_logic);
    end component;
  begin
    INST1: VLO
      port map (Z=>PWR0);
  end Structure;

-- entity CNT_COB
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity CNT_COB is
    -- miscellaneous vital GENERICs
    GENERIC (
      TimingChecksOn	: boolean := TRUE;
      XOn           	: boolean := FALSE;
      MsgOn         	: boolean := TRUE;
      InstancePath  	: string := "CNT_COB";

      tipd_IOLDO  	: VitalDelayType01 := (0 ns, 0 ns);
      tpd_IOLDO_CNTCO	 : VitalDelayType01Z := (0 ns, 0 ns, 0 ns , 0 ns, 0 ns, 0 ns)
        );

    port (IOLDO: in Std_logic; CNTCO: out Std_logic);

    ATTRIBUTE Vital_Level0 OF CNT_COB : ENTITY IS TRUE;

  end CNT_COB;

  architecture Structure of CNT_COB is
    ATTRIBUTE Vital_Level0 OF Structure : ARCHITECTURE IS TRUE;

    signal IOLDO_ipd 	: std_logic := 'X';
    signal CNTCO_out 	: std_logic := 'X';

    signal GNDI: Std_logic;
    component ec2iobuf
      port (I: in Std_logic; T: in Std_logic; PAD: out Std_logic);
    end component;
    component gnd
      port (PWR0: out Std_logic);
    end component;
  begin
    CNT_CO_pad: ec2iobuf
      port map (I=>IOLDO_ipd, T=>GNDI, PAD=>CNTCO_out);
    DRIVEGND: gnd
      port map (PWR0=>GNDI);

    --  INPUT PATH DELAYs
    WireDelay : BLOCK
    BEGIN
      VitalWireDelay(IOLDO_ipd, IOLDO, tipd_IOLDO);
    END BLOCK;

    VitalBehavior : PROCESS (IOLDO_ipd, CNTCO_out)
    VARIABLE CNTCO_zd         	: std_logic := 'X';
    VARIABLE CNTCO_GlitchData 	: VitalGlitchDataType;


    BEGIN

    IF (TimingChecksOn) THEN

    END IF;

    CNTCO_zd 	:= CNTCO_out;

    VitalPathDelay01Z (
      OutSignal => CNTCO, OutSignalName => "CNTCO", OutTemp => CNTCO_zd,
      Paths      => (0 => (InputChangeTime => IOLDO_ipd'last_event,
                           PathDelay => tpd_IOLDO_CNTCO,
                           PathCondition => TRUE)),
      GlitchData => CNTCO_GlitchData,
      Mode       => vitaltransport, XOn => XOn, MsgOn => MsgOn);

    END PROCESS;

  end Structure;

-- entity mfflsre
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity mfflsre is
    port (D0: in Std_logic; SP: in Std_logic; CK: in Std_logic; 
          LSR: in Std_logic; Q: out Std_logic);

    ATTRIBUTE Vital_Level0 OF mfflsre : ENTITY IS TRUE;

  end mfflsre;

  architecture Structure of mfflsre is
    component FD1P3DX
      generic (GSR: String);
      port (D: in Std_logic; SP: in Std_logic; CK: in Std_logic; 
            CD: in Std_logic; Q: out Std_logic);
    end component;
  begin
    INST01: FD1P3DX
      generic map (GSR => "DISABLED")
      port map (D=>D0, SP=>SP, CK=>CK, CD=>LSR, Q=>Q);
  end Structure;

-- entity vcc
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity vcc is
    port (PWR1: out Std_logic);

    ATTRIBUTE Vital_Level0 OF vcc : ENTITY IS TRUE;

  end vcc;

  architecture Structure of vcc is
    component VHI
      port (Z: out Std_logic);
    end component;
  begin
    INST1: VHI
      port map (Z=>PWR1);
  end Structure;

-- entity CNT_CO_MGIOL
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity CNT_CO_MGIOL is
    -- miscellaneous vital GENERICs
    GENERIC (
      TimingChecksOn	: boolean := TRUE;
      XOn           	: boolean := FALSE;
      MsgOn         	: boolean := TRUE;
      InstancePath  	: string := "CNT_CO_MGIOL";

      tipd_ONEG0  	: VitalDelayType01 := (0 ns, 0 ns);
      tipd_LSR  	: VitalDelayType01 := (0 ns, 0 ns);
      tipd_CLK  	: VitalDelayType01 := (0 ns, 0 ns);
      tpd_LSR_IOLDO	 : VitalDelayType01 := (0 ns, 0 ns);
      tpd_CLK_IOLDO	 : VitalDelayType01 := (0 ns, 0 ns);
      ticd_CLK	: VitalDelayType := 0 ns;
      tisd_ONEG0_CLK	: VitalDelayType := 0 ns;
      tsetup_ONEG0_CLK_noedge_posedge	: VitalDelayType := 0 ns;
      thold_ONEG0_CLK_noedge_posedge	: VitalDelayType := 0 ns;
      tisd_LSR_CLK	: VitalDelayType := 0 ns;
      tsetup_LSR_CLK_noedge_posedge	: VitalDelayType := 0 ns;
      thold_LSR_CLK_noedge_posedge	: VitalDelayType := 0 ns);

    port (IOLDO: out Std_logic; ONEG0: in Std_logic; LSR: in Std_logic; 
          CLK: in Std_logic);

    ATTRIBUTE Vital_Level0 OF CNT_CO_MGIOL : ENTITY IS TRUE;

  end CNT_CO_MGIOL;

  architecture Structure of CNT_CO_MGIOL is
    ATTRIBUTE Vital_Level0 OF Structure : ARCHITECTURE IS TRUE;

    signal IOLDO_out 	: std_logic := 'X';
    signal ONEG0_ipd 	: std_logic := 'X';
    signal ONEG0_dly 	: std_logic := 'X';
    signal LSR_ipd 	: std_logic := 'X';
    signal LSR_dly 	: std_logic := 'X';
    signal CLK_ipd 	: std_logic := 'X';
    signal CLK_dly 	: std_logic := 'X';

    signal VCCI: Std_logic;
    component mfflsre
      port (D0: in Std_logic; SP: in Std_logic; CK: in Std_logic; 
            LSR: in Std_logic; Q: out Std_logic);
    end component;
    component vcc
      port (PWR1: out Std_logic);
    end component;
  begin
    CNT_CO_0io: mfflsre
      port map (D0=>ONEG0_dly, SP=>VCCI, CK=>CLK_dly, LSR=>LSR_dly, 
                Q=>IOLDO_out);
    DRIVEVCC: vcc
      port map (PWR1=>VCCI);

    --  INPUT PATH DELAYs
    WireDelay : BLOCK
    BEGIN
      VitalWireDelay(ONEG0_ipd, ONEG0, tipd_ONEG0);
      VitalWireDelay(LSR_ipd, LSR, tipd_LSR);
      VitalWireDelay(CLK_ipd, CLK, tipd_CLK);
    END BLOCK;

    --  Setup and Hold DELAYs
    SignalDelay : BLOCK
    BEGIN
      VitalSignalDelay(ONEG0_dly, ONEG0_ipd, tisd_ONEG0_CLK);
      VitalSignalDelay(LSR_dly, LSR_ipd, tisd_LSR_CLK);
      VitalSignalDelay(CLK_dly, CLK_ipd, ticd_CLK);
    END BLOCK;

    VitalBehavior : PROCESS (IOLDO_out, ONEG0_dly, LSR_dly, CLK_dly)
    VARIABLE IOLDO_zd         	: std_logic := 'X';
    VARIABLE IOLDO_GlitchData 	: VitalGlitchDataType;

    VARIABLE tviol_ONEG0_CLK       	: x01 := '0';
    VARIABLE ONEG0_CLK_TimingDatash	: VitalTimingDataType;
    VARIABLE tviol_LSR_CLK       	: x01 := '0';
    VARIABLE LSR_CLK_TimingDatash	: VitalTimingDataType;

    BEGIN

    IF (TimingChecksOn) THEN
      VitalSetupHoldCheck (
        TestSignal => ONEG0_dly,
        TestSignalName => "ONEG0",
        TestDelay => tisd_ONEG0_CLK,
        RefSignal => CLK_dly,
        RefSignalName => "CLK",
        RefDelay => ticd_CLK,
        SetupHigh => tsetup_ONEG0_CLK_noedge_posedge,
        SetupLow => tsetup_ONEG0_CLK_noedge_posedge,
        HoldHigh => thold_ONEG0_CLK_noedge_posedge,
        HoldLow => thold_ONEG0_CLK_noedge_posedge,
        CheckEnabled => TRUE,
        RefTransition => '/',
        MsgOn => MsgOn, XOn => XOn,
        HeaderMsg => InstancePath,
        TimingData => ONEG0_CLK_TimingDatash,
        Violation => tviol_ONEG0_CLK,
        MsgSeverity => warning);
      VitalSetupHoldCheck (
        TestSignal => LSR_dly,
        TestSignalName => "LSR",
        TestDelay => tisd_LSR_CLK,
        RefSignal => CLK_dly,
        RefSignalName => "CLK",
        RefDelay => ticd_CLK,
        SetupHigh => tsetup_LSR_CLK_noedge_posedge,
        SetupLow => tsetup_LSR_CLK_noedge_posedge,
        HoldHigh => thold_LSR_CLK_noedge_posedge,
        HoldLow => thold_LSR_CLK_noedge_posedge,
        CheckEnabled => TRUE,
        RefTransition => '/',
        MsgOn => MsgOn, XOn => XOn,
        HeaderMsg => InstancePath,
        TimingData => LSR_CLK_TimingDatash,
        Violation => tviol_LSR_CLK,
        MsgSeverity => warning);

    END IF;

    IOLDO_zd 	:= IOLDO_out;

    VitalPathDelay01 (
      OutSignal => IOLDO, OutSignalName => "IOLDO", OutTemp => IOLDO_zd,
      Paths      => (0 => (InputChangeTime => LSR_dly'last_event,
                           PathDelay => tpd_LSR_IOLDO,
                           PathCondition => TRUE),
                     1 => (InputChangeTime => CLK_dly'last_event,
                           PathDelay => tpd_CLK_IOLDO,
                           PathCondition => TRUE)),
      GlitchData => IOLDO_GlitchData,
      Mode       => ondetect, XOn => XOn, MsgOn => MsgOn);

    END PROCESS;

  end Structure;

-- entity ec2iobuf0001
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity ec2iobuf0001 is
    port (Z: out Std_logic; PAD: in Std_logic);

    ATTRIBUTE Vital_Level0 OF ec2iobuf0001 : ENTITY IS TRUE;

  end ec2iobuf0001;

  architecture Structure of ec2iobuf0001 is
    component IBPU
      port (I: in Std_logic; O: out Std_logic);
    end component;
  begin
    INST1: IBPU
      port map (I=>PAD, O=>Z);
  end Structure;

-- entity CLK_IB
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity CLK_IB is
    -- miscellaneous vital GENERICs
    GENERIC (
      TimingChecksOn	: boolean := TRUE;
      XOn           	: boolean := FALSE;
      MsgOn         	: boolean := TRUE;
      InstancePath  	: string := "CLK_IB";

      tipd_CLKI  	: VitalDelayType01 := (0 ns, 0 ns);
      tpd_CLKI_PADDI	 : VitalDelayType01 := (0 ns, 0 ns);
      tperiod_CLKI 	: VitalDelayType := 0 ns;
      tpw_CLKI_posedge	: VitalDelayType := 0 ns;
      tpw_CLKI_negedge	: VitalDelayType := 0 ns);

    port (PADDI: out Std_logic; CLKI: in Std_logic);

    ATTRIBUTE Vital_Level0 OF CLK_IB : ENTITY IS TRUE;

  end CLK_IB;

  architecture Structure of CLK_IB is
    ATTRIBUTE Vital_Level0 OF Structure : ARCHITECTURE IS TRUE;

    signal PADDI_out 	: std_logic := 'X';
    signal CLKI_ipd 	: std_logic := 'X';

    component ec2iobuf0001
      port (Z: out Std_logic; PAD: in Std_logic);
    end component;
  begin
    CLK_I_pad: ec2iobuf0001
      port map (Z=>PADDI_out, PAD=>CLKI_ipd);

    --  INPUT PATH DELAYs
    WireDelay : BLOCK
    BEGIN
      VitalWireDelay(CLKI_ipd, CLKI, tipd_CLKI);
    END BLOCK;

    VitalBehavior : PROCESS (PADDI_out, CLKI_ipd)
    VARIABLE PADDI_zd         	: std_logic := 'X';
    VARIABLE PADDI_GlitchData 	: VitalGlitchDataType;

    VARIABLE tviol_CLKI_CLKI          	: x01 := '0';
    VARIABLE periodcheckinfo_CLKI	: VitalPeriodDataType;

    BEGIN

    IF (TimingChecksOn) THEN
      VitalPeriodPulseCheck (
        TestSignal => CLKI_ipd,
        TestSignalName => "CLKI",
        Period => tperiod_CLKI,
        PulseWidthHigh => tpw_CLKI_posedge,
        PulseWidthLow => tpw_CLKI_negedge,
        PeriodData => periodcheckinfo_CLKI,
        Violation => tviol_CLKI_CLKI,
        MsgOn => MsgOn, XOn => XOn,
        HeaderMsg => InstancePath,
        CheckEnabled => TRUE,
        MsgSeverity => warning);

    END IF;

    PADDI_zd 	:= PADDI_out;

    VitalPathDelay01 (
      OutSignal => PADDI, OutSignalName => "PADDI", OutTemp => PADDI_zd,
      Paths      => (0 => (InputChangeTime => CLKI_ipd'last_event,
                           PathDelay => tpd_CLKI_PADDI,
                           PathCondition => TRUE)),
      GlitchData => PADDI_GlitchData,
      Mode       => vitaltransport, XOn => XOn, MsgOn => MsgOn);

    END PROCESS;

  end Structure;

-- entity ENBL_IB
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity ENBL_IB is
    -- miscellaneous vital GENERICs
    GENERIC (
      TimingChecksOn	: boolean := TRUE;
      XOn           	: boolean := FALSE;
      MsgOn         	: boolean := TRUE;
      InstancePath  	: string := "ENBL_IB";

      tipd_ENBLI  	: VitalDelayType01 := (0 ns, 0 ns);
      tpd_ENBLI_PADDI	 : VitalDelayType01 := (0 ns, 0 ns);
      tperiod_ENBLI 	: VitalDelayType := 0 ns;
      tpw_ENBLI_posedge	: VitalDelayType := 0 ns;
      tpw_ENBLI_negedge	: VitalDelayType := 0 ns);

    port (PADDI: out Std_logic; ENBLI: in Std_logic);

    ATTRIBUTE Vital_Level0 OF ENBL_IB : ENTITY IS TRUE;

  end ENBL_IB;

  architecture Structure of ENBL_IB is
    ATTRIBUTE Vital_Level0 OF Structure : ARCHITECTURE IS TRUE;

    signal PADDI_out 	: std_logic := 'X';
    signal ENBLI_ipd 	: std_logic := 'X';

    component ec2iobuf0001
      port (Z: out Std_logic; PAD: in Std_logic);
    end component;
  begin
    ENBL_I_pad: ec2iobuf0001
      port map (Z=>PADDI_out, PAD=>ENBLI_ipd);

    --  INPUT PATH DELAYs
    WireDelay : BLOCK
    BEGIN
      VitalWireDelay(ENBLI_ipd, ENBLI, tipd_ENBLI);
    END BLOCK;

    VitalBehavior : PROCESS (PADDI_out, ENBLI_ipd)
    VARIABLE PADDI_zd         	: std_logic := 'X';
    VARIABLE PADDI_GlitchData 	: VitalGlitchDataType;

    VARIABLE tviol_ENBLI_ENBLI          	: x01 := '0';
    VARIABLE periodcheckinfo_ENBLI	: VitalPeriodDataType;

    BEGIN

    IF (TimingChecksOn) THEN
      VitalPeriodPulseCheck (
        TestSignal => ENBLI_ipd,
        TestSignalName => "ENBLI",
        Period => tperiod_ENBLI,
        PulseWidthHigh => tpw_ENBLI_posedge,
        PulseWidthLow => tpw_ENBLI_negedge,
        PeriodData => periodcheckinfo_ENBLI,
        Violation => tviol_ENBLI_ENBLI,
        MsgOn => MsgOn, XOn => XOn,
        HeaderMsg => InstancePath,
        CheckEnabled => TRUE,
        MsgSeverity => warning);

    END IF;

    PADDI_zd 	:= PADDI_out;

    VitalPathDelay01 (
      OutSignal => PADDI, OutSignalName => "PADDI", OutTemp => PADDI_zd,
      Paths      => (0 => (InputChangeTime => ENBLI_ipd'last_event,
                           PathDelay => tpd_ENBLI_PADDI,
                           PathCondition => TRUE)),
      GlitchData => PADDI_GlitchData,
      Mode       => vitaltransport, XOn => XOn, MsgOn => MsgOn);

    END PROCESS;

  end Structure;

-- entity RST_IB
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity RST_IB is
    -- miscellaneous vital GENERICs
    GENERIC (
      TimingChecksOn	: boolean := TRUE;
      XOn           	: boolean := FALSE;
      MsgOn         	: boolean := TRUE;
      InstancePath  	: string := "RST_IB";

      tipd_RSTI  	: VitalDelayType01 := (0 ns, 0 ns);
      tpd_RSTI_PADDI	 : VitalDelayType01 := (0 ns, 0 ns);
      tperiod_RSTI 	: VitalDelayType := 0 ns;
      tpw_RSTI_posedge	: VitalDelayType := 0 ns;
      tpw_RSTI_negedge	: VitalDelayType := 0 ns);

    port (PADDI: out Std_logic; RSTI: in Std_logic);

    ATTRIBUTE Vital_Level0 OF RST_IB : ENTITY IS TRUE;

  end RST_IB;

  architecture Structure of RST_IB is
    ATTRIBUTE Vital_Level0 OF Structure : ARCHITECTURE IS TRUE;

    signal PADDI_out 	: std_logic := 'X';
    signal RSTI_ipd 	: std_logic := 'X';

    component ec2iobuf0001
      port (Z: out Std_logic; PAD: in Std_logic);
    end component;
  begin
    RST_I_pad: ec2iobuf0001
      port map (Z=>PADDI_out, PAD=>RSTI_ipd);

    --  INPUT PATH DELAYs
    WireDelay : BLOCK
    BEGIN
      VitalWireDelay(RSTI_ipd, RSTI, tipd_RSTI);
    END BLOCK;

    VitalBehavior : PROCESS (PADDI_out, RSTI_ipd)
    VARIABLE PADDI_zd         	: std_logic := 'X';
    VARIABLE PADDI_GlitchData 	: VitalGlitchDataType;

    VARIABLE tviol_RSTI_RSTI          	: x01 := '0';
    VARIABLE periodcheckinfo_RSTI	: VitalPeriodDataType;

    BEGIN

    IF (TimingChecksOn) THEN
      VitalPeriodPulseCheck (
        TestSignal => RSTI_ipd,
        TestSignalName => "RSTI",
        Period => tperiod_RSTI,
        PulseWidthHigh => tpw_RSTI_posedge,
        PulseWidthLow => tpw_RSTI_negedge,
        PeriodData => periodcheckinfo_RSTI,
        Violation => tviol_RSTI_RSTI,
        MsgOn => MsgOn, XOn => XOn,
        HeaderMsg => InstancePath,
        CheckEnabled => TRUE,
        MsgSeverity => warning);

    END IF;

    PADDI_zd 	:= PADDI_out;

    VitalPathDelay01 (
      OutSignal => PADDI, OutSignalName => "PADDI", OutTemp => PADDI_zd,
      Paths      => (0 => (InputChangeTime => RSTI_ipd'last_event,
                           PathDelay => tpd_RSTI_PADDI,
                           PathCondition => TRUE)),
      GlitchData => PADDI_GlitchData,
      Mode       => vitaltransport, XOn => XOn, MsgOn => MsgOn);

    END PROCESS;

  end Structure;

-- entity GSR5MODE
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity GSR5MODE is
    port (GSRP: in Std_logic);

    ATTRIBUTE Vital_Level0 OF GSR5MODE : ENTITY IS TRUE;

  end GSR5MODE;

  architecture Structure of GSR5MODE is
    signal GSRMODE: Std_logic;
    component INV
      port (A: in Std_logic; Z: out Std_logic);
    end component;
    component GSR
      port (GSR: in Std_logic);
    end component;
  begin
    INST10: INV
      port map (A=>GSRP, Z=>GSRMODE);
    INST20: GSR
      port map (GSR=>GSRMODE);
  end Structure;

-- entity GSR_INSTB
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity GSR_INSTB is
    -- miscellaneous vital GENERICs
    GENERIC (
      TimingChecksOn	: boolean := TRUE;
      XOn           	: boolean := FALSE;
      MsgOn         	: boolean := TRUE;
      InstancePath  	: string := "GSR_INSTB";

      tipd_GSRNET  	: VitalDelayType01 := (0 ns, 0 ns));

    port (GSRNET: in Std_logic);

    ATTRIBUTE Vital_Level0 OF GSR_INSTB : ENTITY IS TRUE;

  end GSR_INSTB;

  architecture Structure of GSR_INSTB is
    signal GSRNET_ipd 	: std_logic := 'X';

    component GSR5MODE
      port (GSRP: in Std_logic);
    end component;
  begin
    GSR_INST_GSRMODE: GSR5MODE
      port map (GSRP=>GSRNET_ipd);

    --  INPUT PATH DELAYs
    WireDelay : BLOCK
    BEGIN
      VitalWireDelay(GSRNET_ipd, GSRNET, tipd_GSRNET);
    END BLOCK;

    VitalBehavior : PROCESS (GSRNET_ipd)


    BEGIN

    IF (TimingChecksOn) THEN

    END IF;



    END PROCESS;

  end Structure;

-- entity TOP_CNT
  library IEEE, vital2000, XP2;
  use IEEE.STD_LOGIC_1164.all;
  use vital2000.vital_timing.all;
  use XP2.COMPONENTS.ALL;

  entity TOP_CNT is
    port (CLK_I: in Std_logic; RST_I: in Std_logic; ENBL_I: in Std_logic; 
          CNT_CO: out Std_logic);



  end TOP_CNT;

  architecture Structure of TOP_CNT is
    signal CNT_2_VCC: Std_logic;
    signal CNT_2_CNT_A_0: Std_logic;
    signal CNT_2_CNT_A: Std_logic;
    signal CNT_2_CNT_A_s_0: Std_logic;
    signal ENBL_I_c: Std_logic;
    signal C1: Std_logic;
    signal CNT_2_CNT_A_cry_0: Std_logic;
    signal CNT_2_CNT_2_O_4: Std_logic;
    signal CNT_2_CNT_2_O_3: Std_logic;
    signal CNT_2_CNT_A_s_4: Std_logic;
    signal CNT_2_CNT_A_s_3: Std_logic;
    signal CNT_2_CNT_A_cry_2: Std_logic;
    signal CNT_2_CNT_A_2: Std_logic;
    signal CNT_2_CNT_A_1: Std_logic;
    signal CNT_2_CNT_A_s_2: Std_logic;
    signal CNT_2_CNT_A_s_1: Std_logic;
    signal CNT_1_CO0: Std_logic;
    signal CNT_1_O_1: Std_logic;
    signal CNT_1_CNT_A_3: Std_logic;
    signal CNT_1_CNT_A_2: Std_logic;
    signal CNT_1_cnt_c2_0_0_i: Std_logic;
    signal CLK_I_c: Std_logic;
    signal CNT_1_CNT_A_3_3: Std_logic;
    signal CNT_1_CNT_A_3_2: Std_logic;
    signal CNT_1_CNT_A_3_0: Std_logic;
    signal CNT_1_CNT_A_3_1: Std_logic;
    signal un7_cnt_2_o: Std_logic;
    signal RST_I_c: Std_logic;
    signal RST_internal: Std_logic;
    signal CNT_2_cnt_a9lto2_0: Std_logic;
    signal CNT_CO_c: Std_logic;
    signal VCCI: Std_logic;
    component VHI
      port (Z: out Std_logic);
    end component;
    component PUR
      port (PUR: in Std_logic);
    end component;
    component CNT_COB
      port (IOLDO: in Std_logic; CNTCO: out Std_logic);
    end component;
    component CNT_CO_MGIOL
      port (IOLDO: out Std_logic; ONEG0: in Std_logic; LSR: in Std_logic; 
            CLK: in Std_logic);
    end component;
    component CLK_IB
      port (PADDI: out Std_logic; CLKI: in Std_logic);
    end component;
    component ENBL_IB
      port (PADDI: out Std_logic; ENBLI: in Std_logic);
    end component;
    component RST_IB
      port (PADDI: out Std_logic; RSTI: in Std_logic);
    end component;
    component GSR_INSTB
      port (GSRNET: in Std_logic);
    end component;
  begin
    CNT_2_SLICE_0I: SCCU2B
      generic map (CLKMUX=>"SIG", CEMUX=>"SIG", CCU2_INJECT1_0=>"NO", 
                   CCU2_INJECT1_1=>"NO", SRMODE=>"ASYNC", LSRONMUX=>"OFF", 
                   INIT0_INITVAL=>"0x00CC", INIT1_INITVAL=>"0x8800", 
                   REG1_SD=>"VHI", CHECK_DI1=>TRUE, CHECK_CE=>TRUE)
      port map (M1=>'X', A1=>CNT_2_CNT_A, B1=>CNT_2_CNT_A_0, C1=>'X', 
                D1=>CNT_2_VCC, DI1=>CNT_2_CNT_A_s_0, DI0=>'X', A0=>'X', 
                B0=>CNT_2_CNT_A, C0=>'X', D0=>CNT_2_VCC, FCI=>'X', M0=>'X', 
                CE=>ENBL_I_c, CLK=>C1, LSR=>'X', FCO=>CNT_2_CNT_A_cry_0, 
                F1=>CNT_2_CNT_A_s_0, Q1=>CNT_2_CNT_A_0, F0=>open, Q0=>open);
    CNT_2_SLICE_1I: SCCU2B
      generic map (CLKMUX=>"SIG", CEMUX=>"SIG", CCU2_INJECT1_0=>"NO", 
                   CCU2_INJECT1_1=>"NO", SRMODE=>"ASYNC", LSRONMUX=>"OFF", 
                   INIT0_INITVAL=>"0x8800", INIT1_INITVAL=>"0x88aa", 
                   REG1_SD=>"VHI", REG0_SD=>"VHI", CHECK_DI1=>TRUE, 
                   CHECK_DI0=>TRUE, CHECK_CE=>TRUE)
      port map (M1=>'X', A1=>CNT_2_CNT_A, B1=>CNT_2_CNT_2_O_4, C1=>'X', 
                D1=>CNT_2_VCC, DI1=>CNT_2_CNT_A_s_4, DI0=>CNT_2_CNT_A_s_3, 
                A0=>CNT_2_CNT_A, B0=>CNT_2_CNT_2_O_3, C0=>'X', D0=>CNT_2_VCC, 
                FCI=>CNT_2_CNT_A_cry_2, M0=>'X', CE=>ENBL_I_c, CLK=>C1, 
                LSR=>'X', FCO=>open, F1=>CNT_2_CNT_A_s_4, Q1=>CNT_2_CNT_2_O_4, 
                F0=>CNT_2_CNT_A_s_3, Q0=>CNT_2_CNT_2_O_3);
    CNT_2_SLICE_2I: SCCU2B
      generic map (CLKMUX=>"SIG", CEMUX=>"SIG", CCU2_INJECT1_0=>"NO", 
                   CCU2_INJECT1_1=>"NO", SRMODE=>"ASYNC", LSRONMUX=>"OFF", 
                   INIT0_INITVAL=>"0x8800", INIT1_INITVAL=>"0x8800", 
                   REG1_SD=>"VHI", REG0_SD=>"VHI", CHECK_DI1=>TRUE, 
                   CHECK_DI0=>TRUE, CHECK_CE=>TRUE)
      port map (M1=>'X', A1=>CNT_2_CNT_A, B1=>CNT_2_CNT_A_2, C1=>'X', 
                D1=>CNT_2_VCC, DI1=>CNT_2_CNT_A_s_2, DI0=>CNT_2_CNT_A_s_1, 
                A0=>CNT_2_CNT_A, B0=>CNT_2_CNT_A_1, C0=>'X', D0=>CNT_2_VCC, 
                FCI=>CNT_2_CNT_A_cry_0, M0=>'X', CE=>ENBL_I_c, CLK=>C1, 
                LSR=>'X', FCO=>CNT_2_CNT_A_cry_2, F1=>CNT_2_CNT_A_s_2, 
                Q1=>CNT_2_CNT_A_2, F0=>CNT_2_CNT_A_s_1, Q0=>CNT_2_CNT_A_1);
    CNT_1_SLICE_3I: SLOGICB
      generic map (CLKMUX=>"SIG", CEMUX=>"SIG", REG0_REGSET=>"SET", 
                   SRMODE=>"ASYNC", LSRONMUX=>"OFF", LUT0_INITVAL=>X"FFFB", 
                   REG0_SD=>"VHI", CHECK_DI0=>TRUE, CHECK_CE=>TRUE)
      port map (M1=>'X', FXA=>'X', FXB=>'X', A1=>'X', B1=>'X', C1=>'X', 
                D1=>'X', DI1=>'X', DI0=>CNT_1_cnt_c2_0_0_i, A0=>CNT_1_CNT_A_2, 
                B0=>CNT_1_CNT_A_3, C0=>CNT_1_O_1, D0=>CNT_1_CO0, M0=>'X', 
                CE=>ENBL_I_c, CLK=>CLK_I_c, LSR=>'X', OFX1=>open, F1=>open, 
                Q1=>open, OFX0=>open, F0=>CNT_1_cnt_c2_0_0_i, Q0=>C1);
    CNT_1_SLICE_4I: SLOGICB
      generic map (CLKMUX=>"SIG", CEMUX=>"SIG", SRMODE=>"ASYNC", 
                   LSRONMUX=>"OFF", LUT0_INITVAL=>X"1222", 
                   LUT1_INITVAL=>X"2004", REG1_SD=>"VHI", REG0_SD=>"VHI", 
                   CHECK_DI1=>TRUE, CHECK_DI0=>TRUE, CHECK_CE=>TRUE)
      port map (M1=>'X', FXA=>'X', FXB=>'X', A1=>CNT_1_CNT_A_2, 
                B1=>CNT_1_CNT_A_3, C1=>CNT_1_O_1, D1=>CNT_1_CO0, 
                DI1=>CNT_1_CNT_A_3_3, DI0=>CNT_1_CNT_A_3_2, A0=>CNT_1_CNT_A_2, 
                B0=>CNT_1_CNT_A_3, C0=>CNT_1_O_1, D0=>CNT_1_CO0, M0=>'X', 
                CE=>ENBL_I_c, CLK=>CLK_I_c, LSR=>'X', OFX1=>open, 
                F1=>CNT_1_CNT_A_3_3, Q1=>CNT_1_CNT_A_3, OFX0=>open, 
                F0=>CNT_1_CNT_A_3_2, Q0=>CNT_1_CNT_A_2);
    CNT_1_SLICE_5I: SLOGICB
      generic map (CLKMUX=>"SIG", CEMUX=>"SIG", SRMODE=>"ASYNC", 
                   LSRONMUX=>"OFF", LUT0_INITVAL=>X"0037", REG0_SD=>"VHI", 
                   CHECK_DI0=>TRUE, CHECK_CE=>TRUE)
      port map (M1=>'X', FXA=>'X', FXB=>'X', A1=>'X', B1=>'X', C1=>'X', 
                D1=>'X', DI1=>'X', DI0=>CNT_1_CNT_A_3_0, A0=>CNT_1_CNT_A_2, 
                B0=>CNT_1_CNT_A_3, C0=>CNT_1_O_1, D0=>CNT_1_CO0, M0=>'X', 
                CE=>ENBL_I_c, CLK=>CLK_I_c, LSR=>'X', OFX1=>open, F1=>open, 
                Q1=>open, OFX0=>open, F0=>CNT_1_CNT_A_3_0, Q0=>CNT_1_CO0);
    CNT_1_SLICE_6I: SLOGICB
      generic map (CLKMUX=>"SIG", CEMUX=>"SIG", SRMODE=>"ASYNC", 
                   LSRONMUX=>"OFF", LUT0_INITVAL=>X"1414", REG0_SD=>"VHI", 
                   CHECK_DI0=>TRUE, CHECK_CE=>TRUE)
      port map (M1=>'X', FXA=>'X', FXB=>'X', A1=>'X', B1=>'X', C1=>'X', 
                D1=>'X', DI1=>'X', DI0=>CNT_1_CNT_A_3_1, A0=>CNT_1_CNT_A_3, 
                B0=>CNT_1_O_1, C0=>CNT_1_CO0, D0=>'X', M0=>'X', CE=>ENBL_I_c, 
                CLK=>CLK_I_c, LSR=>'X', OFX1=>open, F1=>open, Q1=>open, 
                OFX0=>open, F0=>CNT_1_CNT_A_3_1, Q0=>CNT_1_O_1);
    SLICE_7I: SLOGICB
      generic map (CLKMUX=>"SIG", CEMUX=>"VHI", LSRMUX=>"SIG", 
                   REG0_REGSET=>"SET", GSR=>"DISABLED", SRMODE=>"ASYNC", 
                   LUT0_INITVAL=>X"8080", REG0_SD=>"VHI", CHECK_DI0=>TRUE, 
                   CHECK_LSR=>TRUE)
      port map (M1=>'X', FXA=>'X', FXB=>'X', A1=>'X', B1=>'X', C1=>'X', 
                D1=>'X', DI1=>'X', DI0=>un7_cnt_2_o, A0=>CNT_1_O_1, 
                B0=>CNT_2_CNT_2_O_3, C0=>CNT_2_CNT_2_O_4, D0=>'X', M0=>'X', 
                CE=>'X', CLK=>CLK_I_c, LSR=>RST_I_c, OFX1=>open, F1=>open, 
                Q1=>open, OFX0=>open, F0=>un7_cnt_2_o, Q0=>RST_internal);
    CNT_2_SLICE_8I: SLOGICB
      generic map (LUT0_INITVAL=>X"4FFF", LUT1_INITVAL=>X"1111")
      port map (M1=>'X', FXA=>'X', FXB=>'X', A1=>CNT_2_CNT_A_0, 
                B1=>CNT_2_CNT_A_2, C1=>'X', D1=>'X', DI1=>'X', DI0=>'X', 
                A0=>CNT_2_CNT_A_1, B0=>CNT_2_cnt_a9lto2_0, C0=>CNT_2_CNT_2_O_3, 
                D0=>CNT_2_CNT_2_O_4, M0=>'X', CE=>'X', CLK=>'X', LSR=>'X', 
                OFX1=>open, F1=>CNT_2_cnt_a9lto2_0, Q1=>open, OFX0=>open, 
                F0=>CNT_2_CNT_A, Q0=>open);
    CNT_2_SLICE_9I: SLOGICB
      generic map (LUT0_INITVAL=>X"FFFF")
      port map (M1=>'X', FXA=>'X', FXB=>'X', A1=>'X', B1=>'X', C1=>'X', 
                D1=>'X', DI1=>'X', DI0=>'X', A0=>'X', B0=>'X', C0=>'X', 
                D0=>'X', M0=>'X', CE=>'X', CLK=>'X', LSR=>'X', OFX1=>open, 
                F1=>open, Q1=>open, OFX0=>open, F0=>CNT_2_VCC, Q0=>open);
    CNT_COI: CNT_COB
      port map (IOLDO=>CNT_CO_c, CNTCO=>CNT_CO);
    CNT_CO_MGIOLI: CNT_CO_MGIOL
      port map (IOLDO=>CNT_CO_c, ONEG0=>un7_cnt_2_o, LSR=>RST_I_c, 
                CLK=>CLK_I_c);
    CLK_II: CLK_IB
      port map (PADDI=>CLK_I_c, CLKI=>CLK_I);
    ENBL_II: ENBL_IB
      port map (PADDI=>ENBL_I_c, ENBLI=>ENBL_I);
    RST_II: RST_IB
      port map (PADDI=>RST_I_c, RSTI=>RST_I);
    GSR_INST: GSR_INSTB
      port map (GSRNET=>RST_internal);
    VHI_INST: VHI
      port map (Z=>VCCI);
    PUR_INST: PUR
      port map (PUR=>VCCI);
  end Structure;



  library IEEE, vital2000, XP2;
  configuration Structure_CON of TOP_CNT is
    for Structure
    end for;
  end Structure_CON;


