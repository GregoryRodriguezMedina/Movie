export class JsonHeaders extends Headers {
    constructor() {
        super();
        this.append('Content-Type', 'application/json');
        // this.append("accept", "application/json");
        this.append('Accept', 'q=0.8;application/json;q=0.9');
        // let token: any = authService.getAuth().token;
      //  if (!!token && !String.isNullOrWhiteSpace(token.value)) {
      //      this.append(configHelper.getAppConfig().auth.token, token.value);
      //  }
    }
}
