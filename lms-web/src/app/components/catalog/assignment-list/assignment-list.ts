import { Component, OnInit } from '@angular/core';
import {  Router } from '@angular/router';
import { AssignmentService } from '../../../services/assignment';

@Component({
  selector: 'app-assignment-list',
  templateUrl: './assignment-list.html',
  styleUrl: './assignment-list.css',
  standalone: false
})
export class AssignmentListComponent implements OnInit {
  assignments:any[]=[];
  loading=true;

  constructor(private assignmentService:AssignmentService,private router:Router){}

  ngOnInit(): void {
    this.loadAssignments();
  }
  loadAssignments(){
    this.assignmentService.getAssignments().subscribe({
      next:(res)=>{
        this.assignments=res;
        this.loading=false;
      },
      error:(err)=>{
        console.error('Error:',err);
        this.loading=false;
      }
    });
  }

  openDetails(id:number){
    this.router.navigate(['/assignments',id]);
  }

}
