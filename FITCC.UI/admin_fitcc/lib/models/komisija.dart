import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/models/enums/ulogeKomisije.dart';
import 'package:json_annotation/json_annotation.dart';

part 'komisija.g.dart';

@JsonSerializable(explicitToJson: true)
class Komisija {
  int komisijaId;
  int kategorijaId;
  String ime;
  String prezime;
  String email;
  UlogeKomisije role; 
  Kategorija? kategorija; 

  Komisija(
     this.komisijaId,
    this.ime,
    this.prezime ,
    this.email ,
    this.role , 
     this.kategorija, 
     this.kategorijaId, 
  );

  factory Komisija.fromJson(Map<String, dynamic> json) => _$KomisijaFromJson(json);
  Map<String, dynamic> toJson() => _$KomisijaToJson(this);
}
