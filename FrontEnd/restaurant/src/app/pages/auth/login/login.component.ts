import { HttpErrorResponse } from '@angular/common/http';
import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {AuthService} from '../../../core/services/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    loading = false;

    constructor(private route: ActivatedRoute,
        private router: Router, 
        private formBuilder: FormBuilder, private authService: AuthService) {
    }

    ngOnInit(): void {
        this.loginForm = this.formBuilder.group({
            email: [null, [Validators.required, Validators.email]],
            password: [null, [Validators.required]]
        });

        
    }

    submit() {
        this.authService.login(this.loginForm.value).subscribe((data : any)=>{
            localStorage.setItem('token',data.token);
            localStorage.setItem('userId',data.id);
            this.router.navigate(['/home']);
          },
          (err : HttpErrorResponse)=>{
            this.loading = true;
          });
        }

}
