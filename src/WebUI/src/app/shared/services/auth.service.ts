import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import * as auth0 from 'auth0-js';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

(window as any).global = window;

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  auth0 = new auth0.WebAuth({
    clientID: 'u9oIHcQZwSKt4YJFc7bgbs5vJUoMTui3',
    domain: 'felipecardozo.auth0.com',
    responseType: 'token id_token',
    redirectUri: 'http://localhost:4200/',
    audience: 'https://spellbook.felipecardozo.com/',
    scope: 'openid ',
  });


  userProfile: any;
  userId: any;

  constructor(public router: Router, public http: HttpClient) {}

  public login(): void {
    this.auth0.authorize();
  }

  public handleAuthentication(): void {
    this.auth0.parseHash((err, authResult) => {
      if (authResult && authResult.accessToken && authResult.idToken) {
        window.location.hash = '';
        this.setSession(authResult);
        this.router.navigate(['']);
      } else if (err) {
        this.router.navigate(['']);
        console.log(err);
      }
    });
  }

  public getProfile(cb): void {
    const accessToken = localStorage.getItem('access_token');
    if (!accessToken) {
      throw new Error('Access token must exist to fetch profile');
    }

    const self = this;
    this.auth0.client.userInfo(accessToken, (err, profile) => {
      if (profile) {
        self.userProfile = profile;
      }
      cb(err, profile);
    });
  }

  private setSession(authResult): void {
    // Set the time that the Access Token will expire at
    const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
    localStorage.setItem('access_token', authResult.accessToken);
    localStorage.setItem('id_token', authResult.idToken);
    localStorage.setItem('expires_at', expiresAt);
  }

  public logout(): void {
    // Remove tokens and expiry time from localStorage
    localStorage.removeItem('access_token');
    localStorage.removeItem('id_token');
    localStorage.removeItem('expires_at');
    // Go back to the home route
    this.router.navigate(['/']);
  }

  public isAuthenticated(): boolean {
    // Check whether the current time is past the
    // Access Token's expiry time
    const expiresAt = JSON.parse(localStorage.getItem('expires_at') || '{}');
    return new Date().getTime() < expiresAt;
  }
  public getPublic(): void {
    this.http.get('https://localhost:5001/auth/public').subscribe(retval => console.log(retval));
  }

  public getPrivate(): void {
    this.http.get('https://localhost:5001/auth/private', {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${localStorage.getItem('access_token')}`)
    }).subscribe(retval => console.log(retval));
  }

  public getUserId(): void {
    this.http.get('https://localhost:5001/auth/userid', {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${localStorage.getItem('access_token')}`)
    }).subscribe(retval => console.log(retval));
  }

  public getUserinfo(): void {
    this.http.get('https://felipecardozo.auth0.com/userinfo', {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${localStorage.getItem('access_token')}`)
    }).subscribe(retval => this.userId = retval);
  }

  public getClains(): void {
    this.http.get('https://localhost:5001/auth/claims', {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${localStorage.getItem('access_token')}`)
    }).subscribe(retval => console.log(retval));
  }

  public createSpell(): void {
    let CreateSpell = {
      'id':  "021A1EB6-44BB-4AF8-87CC-438689D59CDB",
      'userId':  this.userId.sub,
      'text': "teste"
    } 

    this.http.post('https://localhost:5001/api/spell/createSpell/', CreateSpell, {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${localStorage.getItem('access_token')}`)
    }).subscribe(retval => console.log(retval) );
  }

  public getSpells(): void {
    this.http.get('https://localhost:5001/api/spell/getSpells', {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${localStorage.getItem('access_token')}`)
    }).subscribe(retval => console.log(retval));
  }
}