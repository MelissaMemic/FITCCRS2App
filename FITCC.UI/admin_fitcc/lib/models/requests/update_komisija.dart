import 'package:admin_fitcc/models/enums/ulogeKomisije.dart';
import 'package:json_annotation/json_annotation.dart';
part 'update_komisija.g.dart';

@JsonSerializable()
class KomisijaUpdateRequest {
         String? ime;
         String? prezime;
         String? email;
         UlogeKomisije role;
         int? kategorijaId;

  KomisijaUpdateRequest(
      this.ime,
      this.prezime,
      this.email,
      this.role,
      this.kategorijaId

  );

  factory KomisijaUpdateRequest.fromJson(Map<String, dynamic> json) =>
      _$KomisijaUpdateRequestFromJson(json);

  Map<String, dynamic> toJson() => _$KomisijaUpdateRequestToJson(this);
}
