/* tslint:disable */
import { Injectable } from 'angular2/core';
import { Http, Response, Headers } from 'angular2/http';
import { AddressInfo, QueryOptions_CEvent, CEvent, CLocationInfo, CScheduleInfo, CPlannedActivity, CAddressInfo, Event, LocationInfo, PlannedActivity, ScheduleInfo } from './models';
import 'rxjs/Rx';


@Injectable()
/**
 * Created with angular2-swagger-client-generator v
 */
export class ApiClientService {
	domain:string;
  
  constructor(public http: Http){
    this.domain = '';
  }
  /*
	constructor(public http: Http, options?: any) {
		var domain = (typeof options === 'object') ? options.domain : options;
		this.domain = typeof(domain) === 'string' ? domain : '';
		
		if(this.domain.length === 0) {
			throw new Error('Domain parameter must be specified as a string.');
		}
		
			this.token = (typeof options === 'object') ? (options.token ? options.token : {}) : {};
	}
  */


	/**
  *
	* @method
	* @name ApiAddressInfoGet
	* 
	*/
	public ApiAddressInfoGet() {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
		let uri = `/api/AddressInfo`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiAddressInfoPost
	* @param {AddressInfo} oInstance - 
	* 
	*/
	public ApiAddressInfoPost(oInstance: AddressInfo) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		payload['oInstance'] = oInstance;
		let uri = `/api/AddressInfo`;
	  
		return this.http
			.post(this.domain + uri, JSON.stringify(oInstance), { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiAddressInfoByIdGet
	* @param {string} id - 
	* 
	*/
	public ApiAddressInfoByIdGet(id: string) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		let uri = `/api/AddressInfo/${id}`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiAddressInfoByIdPut
	* @param {string} id - 
	* @param {AddressInfo} oInstance - 
	* 
	*/
	public ApiAddressInfoByIdPut(id: string, oInstance: AddressInfo) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
			
		payload['oInstance'] = oInstance;
		let uri = `/api/AddressInfo/${id}`;
	  
		return this.http
			.put(this.domain + uri, JSON.stringify(oInstance), { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiAddressInfoByIdDelete
	* @param {string} id - 
	* 
	*/
	public ApiAddressInfoByIdDelete(id: string) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		let uri = `/api/AddressInfo/${id}`;
	  
		return this.http
			.delete(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiAddressInfoPrototypeGet
	* 
	*/
	public ApiAddressInfoPrototypeGet() {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
		let uri = `/api/AddressInfo/prototype`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiAggrEventDataGet
	* @param {} oQueryOptions - 
	* 
	*/
	public ApiAggrEventDataGet(oQueryOptions: ) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
      
		if(parameters['oQueryOptions'] !== undefined){
			queryParameters['oQueryOptions'] = parameters['oQueryOptions'];
		}
			
		let uri = `/api/AggrEventData`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiEventGet
	* 
	*/
	public ApiEventGet() {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
		let uri = `/api/Event`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiEventPost
	* @param {Event} oInstance - 
	* 
	*/
	public ApiEventPost(oInstance: Event) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		payload['oInstance'] = oInstance;
		let uri = `/api/Event`;
	  
		return this.http
			.post(this.domain + uri, JSON.stringify(oInstance), { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiEventByIdGet
	* @param {string} id - 
	* 
	*/
	public ApiEventByIdGet(id: string) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		let uri = `/api/Event/${id}`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiEventByIdPut
	* @param {string} id - 
	* @param {Event} oInstance - 
	* 
	*/
	public ApiEventByIdPut(id: string, oInstance: Event) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
			
		payload['oInstance'] = oInstance;
		let uri = `/api/Event/${id}`;
	  
		return this.http
			.put(this.domain + uri, JSON.stringify(oInstance), { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiEventByIdDelete
	* @param {string} id - 
	* 
	*/
	public ApiEventByIdDelete(id: string) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		let uri = `/api/Event/${id}`;
	  
		return this.http
			.delete(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiLocationInfoGet
	* 
	*/
	public ApiLocationInfoGet() {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
		let uri = `/api/LocationInfo`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiLocationInfoPost
	* @param {LocationInfo} oInstance - 
	* 
	*/
	public ApiLocationInfoPost(oInstance: LocationInfo) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		payload['oInstance'] = oInstance;
		let uri = `/api/LocationInfo`;
	  
		return this.http
			.post(this.domain + uri, JSON.stringify(oInstance), { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiLocationInfoByIdGet
	* @param {string} id - 
	* 
	*/
	public ApiLocationInfoByIdGet(id: string) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		let uri = `/api/LocationInfo/${id}`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiLocationInfoByIdPut
	* @param {string} id - 
	* @param {LocationInfo} oInstance - 
	* 
	*/
	public ApiLocationInfoByIdPut(id: string, oInstance: LocationInfo) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
			
		payload['oInstance'] = oInstance;
		let uri = `/api/LocationInfo/${id}`;
	  
		return this.http
			.put(this.domain + uri, JSON.stringify(oInstance), { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiLocationInfoByIdDelete
	* @param {string} id - 
	* 
	*/
	public ApiLocationInfoByIdDelete(id: string) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		let uri = `/api/LocationInfo/${id}`;
	  
		return this.http
			.delete(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiPlannedActivityGet
	* 
	*/
	public ApiPlannedActivityGet() {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
		let uri = `/api/PlannedActivity`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiPlannedActivityPost
	* @param {PlannedActivity} oInstance - 
	* 
	*/
	public ApiPlannedActivityPost(oInstance: PlannedActivity) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		payload['oInstance'] = oInstance;
		let uri = `/api/PlannedActivity`;
	  
		return this.http
			.post(this.domain + uri, JSON.stringify(oInstance), { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiPlannedActivityByIdGet
	* @param {string} id - 
	* 
	*/
	public ApiPlannedActivityByIdGet(id: string) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		let uri = `/api/PlannedActivity/${id}`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiPlannedActivityByIdPut
	* @param {string} id - 
	* @param {PlannedActivity} oInstance - 
	* 
	*/
	public ApiPlannedActivityByIdPut(id: string, oInstance: PlannedActivity) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
			
		payload['oInstance'] = oInstance;
		let uri = `/api/PlannedActivity/${id}`;
	  
		return this.http
			.put(this.domain + uri, JSON.stringify(oInstance), { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiPlannedActivityByIdDelete
	* @param {string} id - 
	* 
	*/
	public ApiPlannedActivityByIdDelete(id: string) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		let uri = `/api/PlannedActivity/${id}`;
	  
		return this.http
			.delete(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiScheduleInfoGet
	* 
	*/
	public ApiScheduleInfoGet() {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
		let uri = `/api/ScheduleInfo`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiScheduleInfoPost
	* @param {ScheduleInfo} oInstance - 
	* 
	*/
	public ApiScheduleInfoPost(oInstance: ScheduleInfo) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		payload['oInstance'] = oInstance;
		let uri = `/api/ScheduleInfo`;
	  
		return this.http
			.post(this.domain + uri, JSON.stringify(oInstance), { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiScheduleInfoByIdGet
	* @param {string} id - 
	* 
	*/
	public ApiScheduleInfoByIdGet(id: string) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		let uri = `/api/ScheduleInfo/${id}`;
	  
		return this.http
			.get(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiScheduleInfoByIdPut
	* @param {string} id - 
	* @param {ScheduleInfo} oInstance - 
	* 
	*/
	public ApiScheduleInfoByIdPut(id: string, oInstance: ScheduleInfo) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
			
		payload['oInstance'] = oInstance;
		let uri = `/api/ScheduleInfo/${id}`;
	  
		return this.http
			.put(this.domain + uri, JSON.stringify(oInstance), { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	
	/**
  *
	* @method
	* @name ApiScheduleInfoByIdDelete
	* @param {string} id - 
	* 
	*/
	public ApiScheduleInfoByIdDelete(id: string) {
		let payload = {};	
		let queryParameters = {};
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		
			
		let uri = `/api/ScheduleInfo/${id}`;
	  
		return this.http
			.delete(this.domain + uri, { headers: headers, params: queryParameters })
			.map((res: Response) => {
        return res;
      });
	}
	

}
