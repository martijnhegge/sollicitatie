/* Little code of aimbot for Black Ops 2 */

private static int GetNearestPlayer(int clientIndex, bool EnemyOnly = false)
{
    int result = 0;
    float num = 1E+08f;
    for (int i = 0; i <= 11; i++)
    {
        if (i != clientIndex)
        {
            if (Aimbot.ClientIsInGame(i) && Aimbot.ClientIsAlive(i))
            {
                if (PS3.Extension.ReadInt32((uint)(24667180 + 22536 * clientIndex)) != 0 && EnemyOnly)
                {
                    if (!Aimbot.ClientIsSameTeam(clientIndex, i))
                    {
                        float num2 = Convert.ToSingle(Aimbot.Distance3D(Aimbot.GetPlayerPosition(clientIndex), Aimbot.GetPlayerPosition(i)));
                        if (num2 < num)
                        {
                            num = num2;
                            result = i;
                        }
                    }
                }
                else
                {
                    float num2 = Convert.ToSingle(Aimbot.Distance3D(Aimbot.GetPlayerPosition(clientIndex), Aimbot.GetPlayerPosition(i)));
                    if (num2 < num)
                    {
                        num = num2;
                        result = i;
                    }
                }
            }
        }
    }
    return result;
}

/* Anti-Ban for PS3 Games*/

// #1
if (metroToggle1.Text == "On")
{
    PS3API arg_19_0 = PS3;
    uint arg_19_1 = 4908140u;
    byte[] array = new byte[4];
    array[0] = 96;
    arg_19_0.SetMemory(arg_19_1, array);
    PS3API arg_55_0 = PS3;
    uint arg_55_1 = 3635652u;
    array = new byte[4];
    array[0] = 96;
    arg_55_0.SetMemory(arg_55_1, array);
    PS3API arg_91_0 = PS3;
    uint arg_91_1 = 3351448u;
    array = new byte[4];
    array[0] = 96;
    arg_91_0.SetMemory(arg_91_1, array);
    PS3API arg_CD_0 = PS3;
    uint arg_CD_1 = 4879088u;
    array = new byte[4];
    array[0] = 96;
    arg_CD_0.SetMemory(arg_CD_1, array);
    PS3API arg_109_0 = PS3;
    uint arg_109_1 = 3725128u;
    array = new byte[4];
    array[0] = 96;
    arg_109_0.SetMemory(arg_109_1, array);
    PS3API arg_145_0 = PS3;
    uint arg_145_1 = 3471496u;
    array = new byte[4];
    array[0] = 96;
    arg_145_0.SetMemory(arg_145_1, array);
    PS3API arg_181_0 = PS3;
    uint arg_181_1 = 5130708u;
    array = new byte[4];
    array[0] = 96;
    arg_181_0.SetMemory(arg_181_1, array);
    MessageBox.Show("Anti-Ban Enabled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    PS3.CCAPI.Notify(PS3Lib.CCAPI.NotifyIcon.HAND, "Anti-Ban Enabled");
    PS3.CCAPI.RingBuzzer(PS3Lib.CCAPI.BuzzerMode.Single);
}
else
{

    MessageBox.Show("Anti-Ban Disabled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    PS3.CCAPI.Notify(PS3Lib.CCAPI.NotifyIcon.HAND, "Anti-Ban Enabled");
    PS3.CCAPI.RingBuzzer(PS3Lib.CCAPI.BuzzerMode.Single);
}

//#2

  //Multplayer
  byte[] array = new byte[4];
  array[0] = 96;
  PS3.SetMemory(8143176u, array);
  byte[] array2 = new byte[4];
  array2[0] = 96;
  PS3.SetMemory(8142928u, array2);
  byte[] array3 = new byte[4];
  array3[0] = 96;
  PS3.SetMemory(8144728u, array3);
  byte[] array4 = new byte[4];
  array4[0] = 96;
  PS3.SetMemory(8144480u, array4);
  //Zombies
  byte[] array5 = new byte[4];
  array[0] = 96;
  PS3.SetMemory(8088032u, array5);
  byte[] array6 = new byte[4];
  array2[0] = 96;
  PS3.SetMemory(8087784u, array6);
  //Cheat Protection
  byte[] expr_13 = new byte[4];
  expr_13[0] = 54;
  expr_13[1] = 96;
  byte[] array7 = expr_13;
  byte[] expr_24 = new byte[4];
  expr_24[0] = 96;
  byte[] array8 = expr_24;
  byte[] expr_30 = new byte[4];
  expr_30[0] = 96;
  byte[] array9 = expr_30;
  PS3.Extension.WriteBytes(6491724u, array7);
  PS3.Extension.WriteBytes(6491684u, array8);
  PS3.Extension.WriteBytes(6455764u, array9);
  MessageBox.Show("Anti-Ban Enabled!");
  PS3.CCAPI.Notify(PS3Lib.CCAPI.NotifyIcon.HAND, "Anti-Ban Enabled");
  PS3.CCAPI.RingBuzzer(PS3Lib.CCAPI.BuzzerMode.Single);
