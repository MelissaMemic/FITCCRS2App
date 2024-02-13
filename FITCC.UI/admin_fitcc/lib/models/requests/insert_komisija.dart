import 'package:admin_fitcc/models/enums/ulogeKomisije.dart';
import 'package:json_annotation/json_annotation.dart';
part 'insert_komisija.g.dart';

@JsonSerializable()
class KomisijaInsertRequest {
         String? ime;
         String? prezime;
         String? email;
         UlogeKomisije role;
         int? kategorijaId;

  KomisijaInsertRequest(
      this.ime,
      this.prezime,
      this.email,
      this.role,
      this.kategorijaId

  );

  factory KomisijaInsertRequest.fromJson(Map<String, dynamic> json) =>
      _$KomisijaInsertRequestFromJson(json);

  Map<String, dynamic> toJson() => _$KomisijaInsertRequestToJson(this);
}
