import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registarForm: FormGroup;
  loading = false;

  constructor(private router: Router, 
    private formBuilder: FormBuilder, 
    private authService: AuthService) { }

  ngOnInit(): void {
    this.registarForm = this.formBuilder.group({
        name: [null, [Validators.required]],
        email: [null, [Validators.required, Validators.email]],
        mobileNumber: [null, [Validators.required]],
        password: [null, [Validators.required]]
    });
  }

submit() {
  this.authService.register(this.registarForm.value).subscribe((data : any)=>{
      localStorage.setItem('token',data.token);
      localStorage.setItem('userId',data.id);
      this.router.navigate(['/home']);
    },
    (err : HttpErrorResponse)=>{
      this.loading = true;
    });
  }

}
