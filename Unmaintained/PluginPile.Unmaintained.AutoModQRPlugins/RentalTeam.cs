using PKHeX.Core;

namespace PluginPile.Unmaintained.AutoModQRPlugins; 
/// <summary>
/// PGL Website QR Rental Team
/// </summary>
public class RentalTeam {
  public readonly IReadOnlyList<QRPK7> Team;
  public IReadOnlyList<byte> GlobalLinkID { get; }
  public IReadOnlyList<byte> UnknownData { get; }
  private static readonly SaveFile Dummy = new SAV7USUM();

  public RentalTeam(byte[] data) {
    Team = new QRPK7[] {
      new QRPK7(data.Slice(0x00, 0x30)),
      new QRPK7(data.Slice(0x30, 0x30)),
      new QRPK7(data.Slice(0x60, 0x30)),
      new QRPK7(data.Slice(0x90, 0x30)),
      new QRPK7(data.Slice(0xC0, 0x30)),
      new QRPK7(data.Slice(0xF0, 0x30)),
    };

    GlobalLinkID = data.Slice(0x120, 8);
    UnknownData = data.AsSpan(0x128).ToArray();
  }

  public IEnumerable<ShowdownSet> ConvertedTeam => Team.Select(z => z.ConvertToPKM(Dummy)).Select(z => new ShowdownSet(z));
}
