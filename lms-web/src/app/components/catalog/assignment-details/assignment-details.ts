// import { Component, OnInit } from '@angular/core';
// import { ActivatedRoute, Router } from '@angular/router';
// import { AssignmentService } from '../../services/assignment';
// import { SubmissionService } from '../../services/submission';

// @Component({
//   selector: 'app-assignment-details',
//   imports: [],
//   templateUrl: './assignment-details.html',
//   styleUrl: './assignment-details.css'
// })
// export class AssignmentDetailsComponent implements OnInit{
//   assignmentId!:number;
//   assignment:any;
//   submissions:any[]=[];
//   userRole = localStorage.getItem('role');

//   studentId = Number(localStorage.getItem('userId'));
//   studentSubmission:any=null;

//   loading=true;

//   constructor(
//     private route:ActivatedRoute,
//     private assignmentService:AssignmentService,
//     private submissionService:SubmissionService,
//     private router:Router
//   ){}

//   ngOnInit(): void {
//     this.assignmentId = Number(this.route.snapshot.paramMap.get('id'));
//     this.loadAssignment();
//   }

//   loadAssignment(){
//     this.assignmentService.getAssignmentsById(this.assignmentId).subscribe({
//       next:(res)=>{
//         this.assignment=res;

//         if(this.userRole==='Instructor'){
//           this.loadSubmissionForInstructor();
//         } 
//         else if(this.userRole==='Student'){
//           this.loadStudentSubmission();
//         }

//         this.loading=false;
//       },

//       error:(err)=>{
//         console.error(err);
//         this.loading = false;
//       }
      
//     });
//   }

//   loadSubmissionForInstructor(){
//     this.submissionService.getSubmissionForAssignment(this.assignmentId).subscribe({
//       next:(res)=>{
//         this.submissions=res;
//       }
//     });
//   }

//   loadStudentSubmission(){
//     this.submissionService.getSubmissionByAssignment(this.assignmentId,this.studentId).subscribe({
//       next:(res)=>{
//         this.studentSubmission=res;
//       }
//     });
//   }

//   goToSubmit(){
//     this.router.navigate(['/assignments', this.assignmentId,'submit']);
//   }

//   grade(submissionId:number){
//     this.router.navigate(['/submission',submissionId,'grade']);
//   }
// }
