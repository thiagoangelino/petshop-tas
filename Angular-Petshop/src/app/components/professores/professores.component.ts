import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Aluno } from '../../models/Aluno';
import { Professor } from '../../models/professor';
import { ProfessorService } from './professor.service';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.scss']
})
export class ProfessoresComponent implements OnInit {

  public titulo = 'Professores';
  public professorSelecionado: Professor;
  public professorForm: FormGroup;
  public modalRef: BsModalRef;
  public modo = 'post';


  public professores: Professor[];
 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
  
  constructor(private fb: FormBuilder, 
              private modalService: BsModalService,
              private professorService: ProfessorService) { 
    this.criarForm();
  }

  ngOnInit() {
    this.carregarProfessores();
  }

  carregarProfessores(){
    this.professorService.getAll().subscribe(
      (professores: Professor[]) => {
        this.professores = professores;
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }

  criarForm(){
    this.professorForm = this.fb.group({
      id: "",
      nome: ['', Validators.required]
      //disciplina: ['']
    });
  }

  salvarProfessor(professor: Professor){
    (professor.id === 0) ? this.modo = 'post' : this.modo = 'put';

    this.professorService[this.modo](professor).subscribe(
      (retorno: Professor) => {
        console.log(retorno);
        this.carregarProfessores();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  professorSubmit(){
    this.salvarProfessor(this.professorForm.value);
  }

  professorSelect(professor: Professor){
    this.professorSelecionado = professor;
    this.professorForm.patchValue(professor);
  }

  professorNovo(){
    this.professorSelecionado = new Professor;
    this.professorForm.patchValue(this.professorSelecionado);
  }
  
  voltar(){
    this.professorSelecionado = null;
  }


}
