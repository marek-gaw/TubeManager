/* eslint-disable @typescript-eslint/adjacent-overload-signatures */
import { Observable } from 'rxjs';
import { Channel } from '../interfaces/channel';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { v4 as uuidv4 } from 'uuid';
import { Injectable } from '@angular/core';

const baseUrl = 'http://localhost:5126/channels';

const httpOptions = {
	headers: new HttpHeaders({
		'Content-Type': 'application/json',
	})
};

@Injectable({ providedIn: 'root' })
export class ChannelsService {

	constructor(private http: HttpClient) { }

	getAll(): Observable<Channel[]> {
		return this.http.get<Channel[]>(baseUrl);
	}

	create(name: string, channelId: string, description: string): Observable<any> {
		const channel: Channel = {
			id: uuidv4(),
			name: name,
			channelId: channelId,
			description: description
		};
		return this.http.post<Channel>(baseUrl, channel, httpOptions);
	}

	edit(channel: Channel): Observable<Channel> {
		const options = { params: new HttpParams().set('id', channel.id) };
		const body = { name: channel.description };
		return this.http.put<Channel>(baseUrl, body, options)
	}

	delete(tag: Channel): Observable<Channel> {
		const options = { params: new HttpParams().set('id', tag.id) };
		return this.http.delete<Channel>(baseUrl, options);
	}
}

