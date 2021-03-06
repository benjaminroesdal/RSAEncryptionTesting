// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: TempSocketServer/game.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from TempSocketServer/game.proto</summary>
public static partial class GameReflection {

  #region Descriptor
  /// <summary>File descriptor for TempSocketServer/game.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static GameReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChtUZW1wU29ja2V0U2VydmVyL2dhbWUucHJvdG8iPQoEZ2FtZRIMCgRuYW1l",
          "GAEgASgJEhEKCWRldmVsb3BlchgCIAEoCRIUCgxyZWxlYXNlX3llYXIYAyAB",
          "KAVCAkgBYgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::game), global::game.Parser, new[]{ "Name", "Developer", "ReleaseYear" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class game : pb::IMessage<game> {
  private static readonly pb::MessageParser<game> _parser = new pb::MessageParser<game>(() => new game());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<game> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::GameReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public game() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public game(game other) : this() {
    name_ = other.name_;
    developer_ = other.developer_;
    releaseYear_ = other.releaseYear_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public game Clone() {
    return new game(this);
  }

  /// <summary>Field number for the "name" field.</summary>
  public const int NameFieldNumber = 1;
  private string name_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Name {
    get { return name_; }
    set {
      name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "developer" field.</summary>
  public const int DeveloperFieldNumber = 2;
  private string developer_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Developer {
    get { return developer_; }
    set {
      developer_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "release_year" field.</summary>
  public const int ReleaseYearFieldNumber = 3;
  private int releaseYear_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int ReleaseYear {
    get { return releaseYear_; }
    set {
      releaseYear_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as game);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(game other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Name != other.Name) return false;
    if (Developer != other.Developer) return false;
    if (ReleaseYear != other.ReleaseYear) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Name.Length != 0) hash ^= Name.GetHashCode();
    if (Developer.Length != 0) hash ^= Developer.GetHashCode();
    if (ReleaseYear != 0) hash ^= ReleaseYear.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
    if (Name.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Name);
    }
    if (Developer.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Developer);
    }
    if (ReleaseYear != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(ReleaseYear);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Name.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
    }
    if (Developer.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Developer);
    }
    if (ReleaseYear != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(ReleaseYear);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(game other) {
    if (other == null) {
      return;
    }
    if (other.Name.Length != 0) {
      Name = other.Name;
    }
    if (other.Developer.Length != 0) {
      Developer = other.Developer;
    }
    if (other.ReleaseYear != 0) {
      ReleaseYear = other.ReleaseYear;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Name = input.ReadString();
          break;
        }
        case 18: {
          Developer = input.ReadString();
          break;
        }
        case 24: {
          ReleaseYear = input.ReadInt32();
          break;
        }
      }
    }
  }

}

#endregion


#endregion Designer generated code
